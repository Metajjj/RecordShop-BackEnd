using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

using RecordShop_BE.Services;

namespace RecordShop_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private IAlbumService service;
        public AlbumController(IAlbumService s)
        {
            service = s;
        }

        [HttpGet]
        public IActionResult GetallAlbums()
        {
            return Ok(service.GetAllAlbums());
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(string id)
        {
            try
            {
                var joke = service.GetAlbumById(id);

                return (joke == null) ? NotFound("Given ID is not found!") : Ok(JsonSerializer.Serialize(joke, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (FormatException ex)
            {
                return BadRequest("Param is NaN! (not a number)");
            }
        }
    }
}
