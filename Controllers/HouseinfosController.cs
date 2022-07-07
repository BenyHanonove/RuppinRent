using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RuppinRent.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace RuppinRent.Controllers
{
    public class HouseinfosController : ApiController
    {
        public IEnumerable<Houseinfo> Get()
        {
            Houseinfo hi = new Houseinfo();
            List<Houseinfo> houses = hi.GetHouseInfo();
            return houses;
        }





        //PUT api/<controller>/5
        public int PUT(string id)
        {
            return 1;
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        

    }
}