using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuppinRent.Models.DAL;

namespace RuppinRent.Models
{
    public class House
    {
        long id;
        string name;
        string description;
        string picture;
        string neighbourhoood;
        string neighbourhooodOverview;
        float score;
        string price;
        char superHost;
        int minimumNights;
        int maximumNights;
        int beds;
        float latitude;
        float longitude;
        int cancelsNum;

        public House(long Id, string Name, string Description, string Picture, string Neighbourhoood,
            string NeighbourhooodOverview, float Score, string Price, char SuperHost,
            int MinimumNights, int MaximumNights, int Beds, float Latitude, float Longitude, int CancelsNum)
        {
            this.id = Id;
            this.name = Name;
            this.description = Description;
            this.picture = Picture;
            this.neighbourhoood = Neighbourhoood;
            this.neighbourhooodOverview = NeighbourhooodOverview;
            this.score = Score;
            this.price = Price;
            this.superHost = SuperHost;
            this.minimumNights = MinimumNights;
            this.maximumNights = MaximumNights;
            this.beds = Beds;
            this.latitude = Latitude;
            this.longitude = Longitude;
            this.cancelsNum = CancelsNum;
            
        }

        public House() { }

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Picture { get => picture; set => picture = value; }
        public string Neighbourhoood { get => neighbourhoood; set => neighbourhoood = value; }
        public string NeighbourhooodOverview { get => neighbourhooodOverview; set => neighbourhooodOverview = value; }
        public float Score { get => score; set => score = value; }
        public string Price { get => price; set => price = value; } 
        public char SuperHost { get => superHost; set => superHost = value; }   
        public int MinimumNights { get => minimumNights; set => minimumNights = value; }
        public int MaximumNights { get => maximumNights; set => maximumNights = value; }
        public int Beds { get => beds; set => beds = value; }
        public float Latitude { get => latitude; set => latitude = value; }
        public float Longitude { get => longitude; set => longitude = value; }
        public int CancelsNum { get => cancelsNum; set => cancelsNum = value; }

        public List<House> GetHouses()
        {
            DataServices ds = new DataServices();
            List<House> houses = ds.GetHouses();
            return houses;
        }


        public House GetHouse(long id)
        {
            DataServices ds = new DataServices();
            House house = ds.GetHouse(id);
            return house;
        }

        public int UpdateRentPlus(House h)
        {
            DataServices ds = new DataServices();
            ds.RentUpdatePlus(h);
            return 1;
        }

    }
}