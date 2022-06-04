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

        public User() { }

        public User(string Email , String Password, string Username)
        {
            this.email = Email;
            this.password = Password;
            this.username = Username;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }

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

    }
}