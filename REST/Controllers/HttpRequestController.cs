using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HttpRequestController : ControllerBase
    {
        
        private readonly ILogger<HttpRequestController> _logger;

        public HttpRequestController(ILogger<HttpRequestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/{str}")]
        public ActionResult<IEnumerable<IGenericRepository>> Get(string str)
        {
            switch (str)
            {
                case "dashboard":
                    return Ok("Pozdrav");
                default:
                    return NotFound("Nema");
            }
        }
  
        [HttpGet("/{str}/{id}")]
        public ActionResult<IEnumerable<IGenericRepository>> GetByID(string str, int id)
        {
            switch (str)
            {
                case "godina":
                    switch (id)
                    {
                        case 1:
                            return Ok("Prva godina");
                        case 2:
                            return Ok("Druga godina");
                        case 3:
                            return Ok("Treća godina");
                        case 4:
                            return Ok("Četvrta godina");
                        default:
                            return NotFound("Nema");
                    }
                case "predmeti":
                    return Ok("List of decks");
                case "profil":
                    return Ok("Profile");
                default:
                    return NotFound("Nema");
            }
        }
        [HttpGet("/{str}/{firstID}/{secondID}")]
        public ActionResult<IEnumerable<IGenericRepository>> GetByIDByID(string str, int firstID, int secondID)
        {
            switch (str)
            {
       
                case "predmeti":
                    return Ok("Deck of cards");
                default:
                    return NotFound("Greška");
            }
        }
        [HttpPost("/{str}/{id}")]
        public ActionResult<IEnumerable<IGenericRepository>> Post(string str, int id)
        {
            switch (str)
            {
                case "predmeti":
                    return Ok("Updated list of decks");
                case "profil":
                    return Ok("Updated profile");
                default:
                    return NotFound("Nema");
            }
        }
        [HttpPost("/{str}/{firstID}/{secondID}")]
        public ActionResult<IEnumerable<IGenericRepository>> PostByIDByID(string str, int firstID, int secondID)
        {
            switch (str)
            {
                case "predmeti":
                    return Ok("Updated deck of cards");
                case "like":
                    return Ok("Liked!");
                case "comment":
                    return Ok("Commented");
                default:
                    return NotFound("Greška");
            }
        }
        [HttpDelete("/{str}/{id}")]
        public ActionResult<IEnumerable<IGenericRepository>> Delete(string str, int id)
        {
            switch (str)
            {
                case "predmeti":
                    return Ok("Deleted subject");
                //case "profil":
                //    return Ok("Deleted profile");
                default:
                    return NotFound("Nema");
            }
        }

        [HttpDelete("/{str}/{firstID}/{secondID}")]
        public ActionResult<IEnumerable<IGenericRepository>> DeleteByIDByID(string str, int firstID, int secondID)
        {
            switch (str)
            {
                case "predmeti":
                    return Ok("Deleted deck of cards");
                case "like":
                    return Ok("Unliked!");
                default:
                    return NotFound("Greška");
            }
        }
    }
}
