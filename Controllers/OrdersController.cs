using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RuppinRent.Models;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;


namespace RuppinRent.Controllers
{
    public class OrdersController : ApiController
    {

        public IEnumerable<Order> Get(string Email)
        {
            Order o = new Order();
            List<Order> orders = o.GetOrders(Email);
            return orders;
        }



        public IEnumerable<Order> Get(long id)
        {
            Order o = new Order();
            List<Order> orders = o.GetOrders(id);
            return orders;
        }


        // POST api/<controller>
        public int Post([FromBody] Order order)
        {
            order.InserOrder();
            return 1;
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Users/Cancel")]
        public int put(User u)
        {
            // User user = new User();
            return u.UpdateCancelMinus(u);
        }


        // DELETE api/<controller>/5
        [System.Web.Http.Route("api/Houses/{Email}/{Id}")]
        public void Delete(string Email,long Id)
        {
            Order order = new Order();
            order.DeleteOrder(Email,Id);
        }
    }
}