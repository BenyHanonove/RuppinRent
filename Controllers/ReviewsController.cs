using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RuppinRent.Models;

namespace RuppinRent.Controllers
{
    public class ReviewsController : ApiController
    {
        // GET: Reviews

        public IEnumerable<Review> Get(float id)
        {
            Review r = new Review();
            List<Review> review = r.GetReviews(id);
            return review;
        }

        public void Post(int id)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id)
        {
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}