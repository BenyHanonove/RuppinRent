using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RuppinRent.Models;

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
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Users/Id")]
        public int Put(int Id)
        {
            User user = new User();
            user.UpdateRentPlus(Id);
            return 1;
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}