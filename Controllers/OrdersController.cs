using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RuppinRent.Models;


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
        public void Put(int id, [FromBody] string value)
        {
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