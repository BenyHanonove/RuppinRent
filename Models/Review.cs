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



        public string NowDateTime()
        {
            DateTime now = DateTime.Now;
            string str = now.Day + "/" + now.Month + "/" + now.Year;
            return str;
        }

        public string SplitEmail()
        {
            String[] spearator = { "s, ", "For" };
            Int32 count = 2;

            // using the method
            String[] strlist = this.reviewerName.Split(spearator, count, StringSplitOptions.RemoveEmptyEntries);

            return strlist[0];
        }

        public List<Review> GetReviews(float id)
        {
            DataServices ds = new DataServices();
            List <Review> reviews = ds.GetReviews(id);
            return reviews;
        }

        public int InserReview()
        {
            DataServices ds = new DataServices();
            ds.InsertReview(this);
            return 1;
        }



    }
}