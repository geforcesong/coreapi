using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using coreapi.Models;
using log4net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coreapi.Controllers
{
    [Route("api/[controller]")]
    public class PropertyController : BaseController
    {
        static List<Property> _properties = new List<Property>();
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(PropertyController));

        static PropertyController(){
            _properties.Add(new Property()
            {
                ID=1,
                Address = "905 Shell blvd",
                State ="CA",
                MlsDb = 12,
                MlsNumber = "3422234"
            });
        }

        [HttpGet]
        [Route("/api/properties")]
        public IEnumerable<Property> Get()
        {
            log.Info("index view");
            log.Error("Controller Error");
            return _properties;
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var p =  _properties.Find(c=>c.ID == id);
            if(p == null){
                return NotFound();
            }
            return Ok(p);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Property property)
        {
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest, "invalid input");
            }
            _properties.Add(property);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Property property)
        {
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest, "invalid input");
            }
            var p = _properties.Find(c => c.ID == id);
            if (p == null)
            {
                return NotFound();
            }
            p.Address = property.Address;
            p.MlsDb = property.MlsDb;
            p.MlsNumber = property.MlsNumber;
            p.State = property.State;
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var p = _properties.Find(c => c.ID == id);
            if (p == null)
            {
                return NotFound();
            }
            _properties.Remove(p);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
