using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
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
        public ActionResult<IEnumerable<Object>> Get(string str, object o)
        {
            switch (str)
            {
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
               
                case "profil":
                    return Ok(_repository.DashboardInfo(new User() { UserID = id }));
                case "skup-kartica":
                    return Ok(_repository.GetById(new DeckOfCards { DeckOfCardsID = id }));
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
                    return Ok(_repository.GetByIdWithPage(new Subject() { SubjectID = firstID }, secondID));

                default:
                    return NotFound("Greška");
            }
        }
        [HttpGet("/pretraga/{searchTerm}/{page}")]
        public ActionResult<IEnumerable<Object>> Search(int page, string searchTerm)
        {
            return Ok(_repository.GetByIdWithPage(new DeckOfCards() { Name = searchTerm }, page));
        }
        [HttpPost("/{str}")]
        public ActionResult<IEnumerable<bool>> Post(string str, object o)
        {
            switch (str)
            {
                case "skupkartica":
                    DeckOfCards deckOfCards = JsonConvert.DeserializeObject<DeckOfCards>(o.ToString(), new IsoDateTimeConverter { DateTimeFormat = "dd-MM-yyyy" });
                    return (Ok(_repository.Add(deckOfCards)));
                case "kartica":
                    Card card = JsonConvert.DeserializeObject<Card>(o.ToString());
                    return (Ok(_repository.Add(card)));
                case "login":
                    User u = new User();
                    u.Username = JObject.FromObject(o).SelectToken("username").Value<string>();
                    if (string.IsNullOrWhiteSpace(u.Username)) return (NotFound("Username nije unet"));

                    u.Password = JObject.FromObject(o).SelectToken("password").Value<string>();
                    if (string.IsNullOrWhiteSpace(u.Password)) return (NotFound("Password nije unet"));

                    return (Ok(_repository.Login(u)));
                case "korisnik":
                    User user = new User();
                    user.Username = JObject.FromObject(o).SelectToken("username").Value<string>();
                    user.Password = JObject.FromObject(o).SelectToken("password").Value<string>();
                    if (string.IsNullOrWhiteSpace(user.Password)) return (NotFound("Stari password nije unet"));
                    //novi password cuvam u mejlu
                    user.Email = JObject.FromObject(o).SelectToken("newPassword").Value<string>();
                    if (string.IsNullOrWhiteSpace(user.Password)) return (NotFound("Novi password nije unet"));

                    return (Ok(_repository.Update(user)));
                case "podkomentar":
                    SubComment subComment = JsonConvert.DeserializeObject<SubComment>(o.ToString());
                    return (Ok(_repository.Add(subComment)));
                case "like":
                    Like like = JsonConvert.DeserializeObject<Like>(o.ToString());
                    return (Ok(_repository.Add(like)));
                case "komentar":
                    Comment comment = JsonConvert.DeserializeObject<Comment>(o.ToString());
                    return (Ok(_repository.Add(comment)));
                default:
                    return NotFound(false);
            }
        }
        [HttpPost("/{str}/{firstID}/{secondID}")]
        public ActionResult<IEnumerable<bool>> PostByIDByID(string str, int firstID, int secondID, object o)
        {
            switch (str)
            {
                case "likee":
                    Like like = new Like
                    {
                        User = new User { UserID = firstID },
                        DeckOfCards = new DeckOfCards { DeckOfCardsID = secondID }
                    };
                    return (Ok(_repository.Add(like)));
                case "comment":
                    Comment comment = JsonConvert.DeserializeObject<Comment>(o.ToString());
                    comment.User = new User
                    {
                        UserID = firstID
                    };
                    comment.DeckOfCards = new DeckOfCards
                    {
                        DeckOfCardsID = secondID
                    };
                    return (Ok(_repository.Add(comment)));
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
                /*case "predmeti":
                    return Ok(_repository.Delete(new DeckOfCards() { DeckOfCardsID = secondID }));*/
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

        [HttpPut("/{str}")]
        public ActionResult<IEnumerable<bool>> Update(string str, object o)
        {
            switch (str)
            {
                case "profil":
                    User user = JsonConvert.DeserializeObject<User>(o.ToString());
                    return (Ok(_repository.Update(user)));
                case "register":
                    User u = new User();
                    u.Username = JObject.FromObject(o).SelectToken("username").Value<string>();
                    if (string.IsNullOrWhiteSpace(u.Username)) return (NotFound("Username nije unet"));

                    u.Password = JObject.FromObject(o).SelectToken("password").Value<string>();
                    if (string.IsNullOrWhiteSpace(u.Password)) return (NotFound("Password nije unet"));

                    u.Email = JObject.FromObject(o).SelectToken("email").Value<string>();
                    if (string.IsNullOrWhiteSpace(u.Email)) return (NotFound("Email nije unet"));


                    return (Ok(_repository.Register(u)));
                case "skupkartica":
                    DeckOfCards deckOfCards = JsonConvert.DeserializeObject<DeckOfCards>(o.ToString(), new IsoDateTimeConverter { DateTimeFormat = "dd-MM-yyyy" });
                    return (Ok(_repository.Update(deckOfCards)));
                default:
                    return NotFound(false);
            }
        }
    }
}
