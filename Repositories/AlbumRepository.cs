using RecordShop_BE.Tables;

namespace RecordShop_BE.Repositories
{
    public interface IAlbumRepository
    {
        public List<Albums> GetAllAlbums();
    }
    public class AlbumRepository : IAlbumRepository
    {
        public List<Albums> GetAllAlbums()
        {
            using (var db = new MyDbContext())
            {
                return db.AlbumTable.ToList();
            }
        }
    }
}
