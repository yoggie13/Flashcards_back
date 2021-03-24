﻿using Microsoft.AspNetCore.Mvc;
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
               /* case "korisnik":
                    User user = JsonConvert.DeserializeObject<User>(o.ToString());
                    return (Ok(_repository.Add(user)));*/
                case "podkomentar":
                    SubComment subComment = JsonConvert.DeserializeObject<SubComment>(o.ToString());
                    return (Ok(_repository.Add(subComment)));
                default:
                    return NotFound(false);
            }
        }
        [HttpPost("/{str}/{firstID}/{secondID}")]
        public ActionResult<IEnumerable<bool>> PostByIDByID(string str, int firstID, int secondID, object o)
        {
            switch (str)
            {
                //razmisliti da li saljemo kroz body ili ovako
                case "like":
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
                    User u = JsonConvert.DeserializeObject<User>(o.ToString());
                    u.Password = JObject.FromObject(o).SelectToken("password").Value<string>();
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
