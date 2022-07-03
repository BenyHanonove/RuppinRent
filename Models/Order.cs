using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuppinRent.Models.DAL;

namespace RuppinRent.Models
{
    public class Order
    {
        string email;
        long houseId;
        DateTime orderdIn;
        DateTime orderdFor;

        public Order() { }


        public Order(string Email, long HouseId,DateTime OrderFor)
        {
            this.email = Email;
            this.houseId = HouseId;
            this.orderdIn = DateTime.Now;
            this.orderdFor = OrderFor;
        }

        public Order(string Email, long HouseId,DateTime OrderdIn, DateTime OrderFor)
        {
            this.email = Email;
            this.houseId = HouseId;
            this.orderdIn = OrderdIn;
            this.orderdFor = OrderFor;
        }


        public string Email { get => email; set => email = value; }
        public long HouseId { get => houseId; set => houseId = value; }
        public DateTime OrderdIn { get => orderdIn; set => orderdIn = value; }
        public DateTime OrderdFor { get => orderdFor; set => orderdFor = value; }

        public string StringDateIn()
        {
            string str = "";
            str += this.orderdIn.Year.ToString() + "-";
            str += this.orderdIn.Month.ToString() + "-";
            str += this.orderdIn.Day.ToString() ;
            return str;
        }

        public string StringDateFor()
        {
            string str = "";
            str += this.OrderdFor.Year.ToString()+"-";
            str += this.orderdFor.Month.ToString()+"-";
            str += this.orderdFor.Day.ToString();
            return str;
        }
        public int InserOrder()
        {
            DataServices ds = new DataServices();
            ds.InsertOrder(this);
            return 1;
        }

        public List<Order> GetOrders(string e)
        {
            DataServices ds = new DataServices();
            List<Order> orders = ds.GetOrders(e);
            return orders;
        }

        public int DeleteOrder(string e , long id)
        {
            DataServices ds =new DataServices();
            ds.DeleteOrder(e, id);
            return 1;
        }

    }
}