﻿using Microsoft.AspNetCore.Mvc;
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
        private EFCoreController _efccontroller;

        public HttpRequestController(ILogger<HttpRequestController> logger)
        {
            _logger = logger;
            _efccontroller = new EFCoreController();
        }

        [HttpGet("/{str}")]
        public ActionResult<IEnumerable<Object>> Get(string str)
        {
            switch (str)
            {
                case "dashboard":
                    //kad se vraca vise razlicitih json-a mozemo ih spojiti preko jsonresult[], pa onda je svaki new jsonresult()
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
                    return Ok(_efccontroller.Select(new Subject() { SubjectID = id}));
                case "profil":
                    return Ok(new User());
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
                    return Ok(new DeckOfCards());

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
                    return Ok(true);
                case "profil":
                    return Ok(true);
                default:
                    return NotFound(false);
            }
        }
        [HttpPost("/{str}/{firstID}/{secondID}")]
        public ActionResult<IEnumerable<bool>> PostByIDByID(string str, int firstID, int secondID)
        {
            switch (str)
            {
                case "predmeti":
                    return Ok(true);
                case "like":
                    return Ok(true);
                case "comment":
                    return Ok(true);
                default:
                    return NotFound(false);
            }
        }
        [HttpDelete("/{str}/{id}")]
        public ActionResult<IEnumerable<bool>> Delete(string str, int id)
        {
            switch (str)
            {
                case "predmeti":
                    return Ok(true);
                //case "profil":
                //    return Ok("Deleted profile");
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
                    return Ok(true);
                case "like":
                    return Ok(true);
                default:
                    return NotFound(false);
            }
        }
    }
}
