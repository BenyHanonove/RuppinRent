using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RuppinRent.Models.DAL;

namespace RuppinRent.Models
{
    public class User
    {

        string email;
        string password;
        string username;
        DateTime joinDate;
        int rentTotal;
        int cancelTotal;
        int id;
        public User() { }

        public User(string Email ,string Password ,string Username ,int ID)
        {
            this.email = Email;
            this.password = Password;
            this.username = Username;
            this.joinDate = DateTime.Now;
            this.rentTotal = 0;
            this.cancelTotal = 0;
            this.id = 0;
        }

        public User(string Email, string Password, string Username ,DateTime JoinDate,int RentTotal,int CancelTotal ,int Id)
        {
            this.email = Email;
            this.password = Password;
            this.username = Username;
            this.joinDate = JoinDate;
            this.rentTotal = RentTotal;
            this.cancelTotal = CancelTotal;
            this.id=Id;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
        public DateTime JoinDate { get => joinDate; set => joinDate = value; }
        public int RentTotal { get => rentTotal; set => rentTotal = value; }
        public int CancelTotal { get => cancelTotal; set => cancelTotal = value; }
        public int Id { get => id; set => id = value; }



        public string StringDateJoin()
        {
            string str = "";
            str += this.joinDate.Year.ToString() + "-";
            str += this.joinDate.Month.ToString() + "-";
            str += this.joinDate.Day.ToString();
            return str;
        }

        public List<User> GetUsers()
        {
            DataServices ds = new DataServices();
            List<User> users = ds.GetUsers();
            return users;
        }

        public int InsertUser()
        {
            DataServices ds = new DataServices();
            ds.InsertUser(this);
            return 1;
        }

        public int UpdateRentPlus(User u)
        {
            DataServices ds = new DataServices();
            ds.RentUpdatePlus(u);
            return 1;
        }
    }
}