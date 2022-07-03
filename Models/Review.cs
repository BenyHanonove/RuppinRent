using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuppinRent.Models.DAL;

namespace RuppinRent.Models
{
    public class Review
    {
        float listingId;
        float id;
        string date;
        float reviewerId;
        string reviewerName;
        string commemts;

        public Review() { }


        public Review (float ListingId ,float Id ,string Date ,float ReviewerId,string ReviewerName,string Comments)
        {
            this.listingId = ListingId;
            this.id = Id;
            this.date = Date;
            this.reviewerId = ReviewerId;
            this.reviewerName = ReviewerName;
            this.commemts = Comments;
        }

        public float ListingId { get => listingId; set => listingId = value; }
        public float Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public float ReviewerId { get => reviewerId; set => reviewerId = value; }
        public string ReviewerName { get => reviewerName; set => reviewerName = value; }
        public string Comments { get => commemts; set => commemts = value; }

        public List<Review> GetReviews(float id)
        {
            DataServices ds = new DataServices();
            List <Review> reviews = ds.GetReviews(id);
            return reviews;
        }



    }
}