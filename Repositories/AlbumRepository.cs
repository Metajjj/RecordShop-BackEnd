using RecordShop_BE.Tables;

namespace RecordShop_BE.Repositories
{
    public interface IAlbumRepository
    {
        public List<Albums> GetAllAlbums();
        public Albums GetAlbumById(int id);
    }
    public class AlbumRepository : IAlbumRepository
    {
        private MyDbContext context;
        public AlbumRepository(MyDbContext context)
        { this.context = context; }

        public List<Albums> GetAllAlbums()
        {
            return context.AlbumTable.ToList();
        }

        public Albums GetAlbumById(int id)
        {
            return context.AlbumTable.ToList().FirstOrDefault(a => a.Id == id);
        }
    }
}
