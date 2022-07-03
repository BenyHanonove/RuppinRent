using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RuppinRent.Models;

namespace RuppinRent.Controllers
{
    public class HousesController : ApiController
    {
        public IEnumerable<House> Get()
        {
            House h = new House();
            List<House> houses = h.GetHouses();
            return houses;
        }

        public House Get(string id)
        {
            House h = new House();
            long newId = Convert.ToInt64(id);
            House house = h.GetHouse(newId);
            return house;
        }

        public void Put(int id, [FromBody] string value)
        {
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}