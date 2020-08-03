using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using JuegoApi.Data;
using JuegoApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.FileProviders;

namespace JuegoApi.Controllers
{
    [Route("api/Apuestas")]
    [ApiController]
    public class ApuestasController : ControllerBase
    {
        private readonly ApuestasDb _apuestaDb;
        public ApuestasController(ApuestasDb apuestadb)
        {
            _apuestaDb = apuestadb;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_apuestaDb.Get());
        }

        [HttpGet("{id:length(24)}", Name = "GetApuesta")]
        public IActionResult GetById(string id)
        {
            var ruleta = _apuestaDb.GetById(id);
            if (ruleta == null)
            {
                return NotFound();
            }
            return Ok(ruleta);
        }

        [HttpPost]
        public IActionResult Create(Apuesta apuesta)
        {
            _apuestaDb.Create(apuesta);
            return CreatedAtRoute("GetApuesta", new
            {
                id = apuesta.Id.ToString()
            }, apuesta);

        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Apuesta rule)
        {
            var apuesta = _apuestaDb.GetById(id);
            if (apuesta == null)
            {
                return NotFound();
            }
            _apuestaDb.Update(id, rule);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteById(string id)
        {
            var apuesta = _apuestaDb.GetById(id);
            if (apuesta == null)
            {
                return NotFound();
            }
            _apuestaDb.DeleteById(apuesta.Id);
            return NoContent();
        }
    }
}






