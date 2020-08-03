using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using JuegoApi.Data;
using JuegoApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.FileProviders;

namespace JuegoApi.Controllers
{
    [Route("api/Ruletas")]
    [ApiController]
    public class RuletasController : ControllerBase
    {
        public RuletasDb _ruletaDb;
        public RuletasController(RuletasDb ruletadb)
        {
            _ruletaDb = ruletadb;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ruletaDb.Get());
        }

        [HttpGet("{id:length(24)}", Name = "GetRuleta")]
        public IActionResult GetById(string id)
        {
            var ruleta = _ruletaDb.GetById(id);
            if (ruleta == null)
            {
                return NotFound();
            }
            return Ok(ruleta);
        }

        [HttpPost]
        public IActionResult Create(Ruleta ruleta)
        {
            _ruletaDb.Create(ruleta);
            return CreatedAtRoute("GetRuleta", new
            {
                id = ruleta.Id.ToString()
            }, ruleta);

        }
        [AllowAnonymous]
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Ruleta rule)
        {
            var ruleta = _ruletaDb.GetById(id);
            if (ruleta == null)
            {
                return NotFound();
            }
            _ruletaDb.Update(id, rule);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteById(string id)
        {
            var ruleta = _ruletaDb.GetById(id);
            if (ruleta == null)
            {
                return NotFound();
            }
            _ruletaDb.DeleteById(ruleta.Id);
            return NoContent();
        }
    }
}






