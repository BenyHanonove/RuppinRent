using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuppinRent.Models.DAL;

namespace RuppinRent.Models
{
    public class Houseinfo
    {
        int houseId;
        int rentNumOfDays;
        int totalCancels;

        public Houseinfo() { }
        public Houseinfo(int houseId, int rentNumOfDays, int totalCancels)
        {
            this.houseId = houseId;
            this.rentNumOfDays = rentNumOfDays;
            this.totalCancels = totalCancels;
        }

        public int HouseId { get => houseId; set => houseId = value; }
        public int RentNumOfDays { get => rentNumOfDays; set => rentNumOfDays = value; }
        public int TotalCancels { get => totalCancels; set => totalCancels = value; }

        public List<Houseinfo> GetHouseInfo()
        {
            DataServices ds = new DataServices();
            List<Houseinfo> h = ds.GetHouseInfo();
            return h;
        }
    }

  }
