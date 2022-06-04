using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuppinRent.Models.DAL;

namespace RuppinRent.Models
{
    public class House
    {
        float id;
        string name;
        string description;
        string picture;
        string neighbourhoood;
        string neighbourhooodOverview;
        float score; 

        public House(float Id ,string Name ,string Description ,string Picture , string Neighbourhoood ,string NeighbourhooodOverview ,float Score)
        {
            this.id = Id;
            this.name = Name;
            this.description = Description;
            this.picture = Picture;
            this.neighbourhoood = Neighbourhoood;
            this.neighbourhooodOverview = NeighbourhooodOverview;
            this.score = Score;

        }

        public House() { }

        public float Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Picture { get => picture; set => picture = value; }
        public string Neighbourhoood { get => neighbourhoood; set => neighbourhoood = value; }
        public string NeighbourhooodOverview { get => neighbourhooodOverview; set => neighbourhooodOverview = value; }
        public float Score { get => score; set => score = value; }

        public List<House> GetHouses()
        {
            DataServices ds = new DataServices();
            List<House> houses = ds.GetHouses();
            return houses;
        }

        public House GetHouse(float id)
        {
            DataServices ds = new DataServices();
            House house = ds.GetHouse(id);
            return house;
        }

    }
}