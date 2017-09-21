using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdressController : Controller
    {
        private BLLFacade facade = new BLLFacade();
        // GET: api/Address
        [HttpGet]
        public IEnumerable<AdressBO> Get()
        {
            return facade.AdressService.GetAll();
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public AdressBO Get(int id)
        {
            return facade.AdressService.Get(id);
        }
        
        // POST: api/Address
        [HttpPost]
        public IActionResult Post([FromBody]AdressBO adress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.AdressService.Create(adress));
        }
        
        // PUT: api/Address/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AdressBO adress)
        {
            if (id != adress.Id)
            {
                return BadRequest("Path Id does not match Address ID in json object");
            }
            try
            {
                return Ok(facade.AdressService.Update(adress));
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.AdressService.Delete(id);
        }
    }
}
