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
        int id; 
        DateTime orderdOut;
        string price;

        public Order() { }


        public Order(string Email, long HouseId,DateTime OrderFor ,DateTime OrderOut)
        {
            this.email = Email;
            this.houseId = HouseId;
            this.orderdIn = DateTime.Now;
            this.orderdFor = OrderFor;
            this.orderdOut = OrderOut;
        }

        public Order(string Email, long HouseId, DateTime OrderdIn, DateTime OrderFor, int Id, DateTime OrderOut, string price)
        {
            this.email = Email;
            this.houseId = HouseId;
            this.orderdIn = OrderdIn;
            this.orderdFor = OrderFor;
            this.id = Id;
            this.orderdOut = OrderOut;
            this.price = price;
        }


        public string Email { get => email; set => email = value; }
        public long HouseId { get => houseId; set => houseId = value; }
        public DateTime OrderdIn { get => orderdIn; set => orderdIn = value; }
        public DateTime OrderdFor { get => orderdFor; set => orderdFor = value; }
        public int Id { get => id; set => id = value; }
        public DateTime OrderdOut { get => orderdOut; set => orderdOut = value; }
        public string Price { get => price; set => price = value; }


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

        public string StringDateOut()
        {
            string str = "";
            str += this.orderdOut.Year.ToString() + "-";
            str += this.orderdOut.Month.ToString() + "-";
            str += this.orderdOut.Day.ToString();
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

        public List<Order> GetAllOrders()
        {
            DataServices ds = new DataServices();
            List<Order> orders = ds.GetAllOrders();
            return orders;
        }

        public List<Order> GetOrders(long Id)
        {
            DataServices ds = new DataServices();
            List<Order> orders = ds.GetOrders(Id);
            return orders;
        }

        public int DeleteOrder(Order order)
        {
            DataServices ds = new DataServices();
            ds.DeleteOrder(order);
            return 1;
        }

    }
}