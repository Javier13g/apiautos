using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiautos.Data;
using apiautos.Data.Configuration;
using apiautos.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiautos.Controllers
{
    [Route("api/autos")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        private readonly Autodb _autodb;

        public AutosController(Autodb autodb)
        {
            _autodb = autodb;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_autodb.Get());
        }

        [HttpGet("{id:length(24)}", Name = "GetAutos")]
        public IActionResult GetById(string id)
        {
            var auto = _autodb.GetById(id);
            if (auto == null)
            {
                return NotFound();
            }

            return Ok(auto);
        }

        public IActionResult Create(Marca auto)
        {
            _autodb.Create(auto);
            return CreatedAtRoute("GetAutos", new
            {
                id = auto.Id.ToString()
            }, auto);
        }
        
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Marca marc)
        {
            var autos = _autodb.GetById(id);
            if (autos == null)
            {
                return NotFound();
            }
            _autodb.Update(id, marc);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var autos = _autodb.GetById(id);

            if (autos == null)
            {
                return NotFound();
            }
            
            _autodb.DeleteById(autos.Id);

            return NoContent();
        }
    }
}