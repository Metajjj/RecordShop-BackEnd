using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

using RecordShop_BE.Services;
using RecordShop_BE.Tables;

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


        [HttpPost]
        public IActionResult PostAlbum(Albums a)
        {
            //Only accept album object post, nothing else! i.e. if fails to json.Deserialize, throw err

            //returns 400 if ierror

            return Ok("Successfully added "+a.Title+" with ID of "+service.PostAlbum(a).Id);
        }
    }
}
