using RecordShop_BE.Repositories;
using RecordShop_BE.Tables;

namespace RecordShop_BE.Services
{
    public interface IAlbumService
    {
        List<Albums> GetAllAlbums();
    }

    public class AlbumService : IAlbumService
    {
        private IAlbumRepository _albumRepository;
        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }
        public List<Albums> GetAllAlbums()
        {
            return _albumRepository.GetAllAlbums();
        }
    }
}
