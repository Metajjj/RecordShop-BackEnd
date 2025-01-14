using Microsoft.AspNetCore.Mvc;

using RecordShop_BE.Services;

namespace RecordShop_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private IAlbumService albumService;
        public AlbumController(IAlbumService Service)
        {
            albumService = Service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(albumService.GetAllAlbums());
        }
    }
}
