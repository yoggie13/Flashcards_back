using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST.Model;
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
        private GenericRepository _repository;

        public HttpRequestController(ILogger<HttpRequestController> logger)
        {
            _logger = logger;
            _repository = new GenericRepository();
        }

        [HttpGet("/{str}")]
        public ActionResult<IEnumerable<Object>> Get(string str)
        {
            switch (str)
            {
                case "dashboard":
                    //kad se vraca vise razlicitih json-a mozemo ih spojiti preko jsonresult[], pa onda je svaki new jsonresult()
                    return (Ok("Ovo treba srediti"));
                default:
                    return NotFound("Nema");
            }
        }

        [HttpGet("/{str}/{id}")]
        public ActionResult<IEnumerable<Object>> GetByID(string str, int id)
        {
            switch (str)
            {
                case "godina":
                    return Ok(_repository.GetById(new Subject() { Year = id }));
                case "predmeti":
                    return Ok(_repository.GetById(new Subject() { SubjectID = id }));
                case "profil":
                    return Ok(_repository.GetById(new User() { UserID = id }));
                default:
                    return NotFound("Nema");
            }
        }
        [HttpGet("/{str}/{firstID}/{secondID}")]
        public ActionResult<IEnumerable<Object>> GetByIDByID(string str, int firstID, int secondID)
        {
            switch (str)
            {
                case "predmeti":
                    return Ok(_repository.GetById(new DeckOfCards() { DeckOfCardsID = secondID }));

                default:
                    return NotFound("Greška");
            }
        }
        [HttpPost("/{str}/{id}")]
        public ActionResult<IEnumerable<bool>> Post(string str, int id)
        {
            switch (str)
            {
                case "predmeti":
                  
                    return (Ok("Ovo treba srediti"));

                default:
                    return NotFound(false);
            }
        }
        [HttpPost("/{str}/{firstID}/{secondID}")]
        public ActionResult<IEnumerable<bool>> PostByIDByID(string str, int firstID, int secondID)
        {
            switch (str)
            {
                case "like":
                    
                    return (Ok("Ovo treba srediti"));

                case "comment":
                 
                    return (Ok("Ovo treba srediti"));

                default:
                    return NotFound(false);
            }
        }
        [HttpDelete("/{str}/{id}")]
        public ActionResult<IEnumerable<bool>> Delete(string str, int id)
        {
            switch (str)
            {

                default:
                    return NotFound(false);
            }
        }

        [HttpDelete("/{str}/{firstID}/{secondID}")]
        public ActionResult<IEnumerable<bool>> DeleteByIDByID(string str, int firstID, int secondID)
        {
            switch (str)
            {
                case "predmeti":
                    return Ok(_repository.Delete(new DeckOfCards() { DeckOfCardsID = secondID }));
                case "like":
                    return Ok(_repository.Delete(new Like()
                    {
                        DeckOfCards = new DeckOfCards() { DeckOfCardsID = firstID },
                        User = new User() { UserID = secondID }
                    }));
                default:
                    return NotFound(false);
            }
        }
    }
}
