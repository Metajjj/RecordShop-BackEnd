using System.Text.Json;

using RecordShop_BE.Tables;

namespace RecordShop_BE.Repositories
{
    public interface IAlbumRepository
    {
        public List<Albums> GetAllAlbums();
        public Albums GetAlbumById(int id);
        public Albums PostAlbum(Albums a);
        public bool PutAlbum(Albums a);
    }
    public class AlbumRepository : IAlbumRepository
    {
        private MyDbContext context;
        public AlbumRepository(MyDbContext context)
        { this.context = context; }

        public List<Albums> GetAllAlbums()
        {
            //memory-db returns entries as they were added, does not sort by ID or anything implicit!

            return context.AlbumTable.OrderBy(a=>a.Id).ToList();
        }

        public Albums GetAlbumById(int id)
        {
            return context.AlbumTable.ToList().FirstOrDefault(a => a.Id == id);
        }

            //TODO refactor else will block large DBs ??
        private int PlugInAlbumGaps()
        {
            var data = context.AlbumTable.OrderBy(a => a.Id).ToList();
            //TODO fix.. if id2 exists only.. starts 1 retursn 1+1

            for(int i = 0; i <= data.Count(); i++){
                try
                {
                    if (data[i].Id != i +1)
                    { return i +1; }
                } catch (ArgumentOutOfRangeException e)
                {
                    return i+1;
                }
            }

            return data.Count()+1;
        }

        public Albums PostAlbum(Albums a)
        {

            a.Id = PlugInAlbumGaps();

            context.AlbumTable.Add(a);
                //Replaces existing ??
            
            
            context.SaveChanges(); 
            return a;
        }

        public bool PutAlbum(Albums a)
        {
            //See if any diff / exists ?
            var A = GetAlbumById(a.Id);

            if (A != null)
            {
                //exists
                if( JsonSerializer.Serialize(a).Equals( JsonSerializer.Serialize( A ) ))
                {
                    //Is same!
                    return false;
                }
                //Not same!
                //TODO ID 6 is not treated as PK ??
                //context.AlbumTable.Update(a);
                    
                    //If tracked/grabbed from db.. set values than update it!
                context.Entry(A).CurrentValues.SetValues(a);

                return true;
            }
            throw new ArgumentNullException("Given ID not found in DB!");
        }
    }
}
