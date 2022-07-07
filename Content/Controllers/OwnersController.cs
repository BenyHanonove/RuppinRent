using RuppinRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RuppinRent.Controllers
{
    public class OwnersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Owner> Get()
        {
            Owner o = new Owner();
            List<Owner> owners = o.GetOwners();
            return owners;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}