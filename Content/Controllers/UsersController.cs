using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RuppinRent.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace RuppinRent.Controllers
{
    public class UsersController : ApiController
    {

        public IEnumerable<User> Get()
        {
            User u = new User();
            List<User> users = u.GetUsers();
            return users;
        }

        // POST api/<controller>
        public int Post([FromBody] User user)
        {
            user.InsertUser();
            return 1;
        }


        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Users/data")]
        public int PUT(User u)
        {
           // User user = new User();
            return u.UpdateRentPlus(u);
        }


        // DELETE api/<controller>/5
        public int Delete(int id)
        {
            User user = new User();
           return user.DeleteUser(id);
        }

    }
}