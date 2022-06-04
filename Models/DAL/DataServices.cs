using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RuppinRent.Models.DAL
{
    public class DataServices
    {
        public DataServices() { }

        public int InsertUser(User u)
        {
            SqlConnection con = Connect();

            //create insert command string for sql
            string strCommand = "insert into usersHotel (email,password,username) values"+
            "('"+u.Email+"','"+u.Password+"','"+u.Username+"'); ";

            SqlCommand com = CreateCommand(strCommand, con);
            return 1;
        }

        public List<User> GetUsers()
        {
            SqlConnection con =Connect();
            string commandStr = "select * from usersHotel";
            SqlCommand command = new SqlCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List <User> users = new List<User>();

            while (dr.Read())
            {
                string email = dr["email"].ToString();
                string password = dr["password"].ToString();
                string username = dr["username"].ToString();
                users.Add(new User(email, password, username));
            }

            return users;
        }

        public List<House> GetHouses()
        {
            SqlConnection con = Connect();
            string commandStr = "select * from Houses";
            SqlCommand command = CreateCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<House> houses = new List<House>();

            while (dr.Read())
            {
                float Id = float.Parse(dr["id"].ToString());
                string Name =dr["name"].ToString();
                string Description =dr["description"].ToString();
                string Picture = dr["picture_url"].ToString();
                string Neighbourhoood = dr["neighbourhood"].ToString();
                string NeighbourhooodOverview = dr["neighborhood_overview"].ToString();
                float Score = float.Parse(dr["review_scores_rating"].ToString());

                houses.Add(new House(Id, Name, Description, Picture, Neighbourhoood, NeighbourhooodOverview, Score));
            }

            return houses;

        }

        public House GetHouse(float HouseId)
        {
            string id = HouseId.ToString();
            SqlConnection con = Connect();
            string commandStr = "select * from Houses where id = " + id;
            SqlCommand command = CreateCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            House house = new House();

            while (dr.Read())
            {
                float Id = float.Parse(dr["id"].ToString());
                string Name = dr["name"].ToString();
                string Description = dr["description"].ToString();
                string Picture = dr["picture_url"].ToString();
                string Neighbourhoood = dr["neighbourhood"].ToString();
                string NeighbourhooodOverview = dr["neighborhood_overview"].ToString();
                float Score = float.Parse(dr["review_scores_rating"].ToString());
                house = new House(Id, Name, Description, Picture, Neighbourhoood, NeighbourhooodOverview, Score);
            }

            return house; 
        }

        public List<Review> GetReviews(float houseId)
        {
            string id = houseId.ToString();
            SqlConnection con =Connect();
            string commandStr = "select *from Reviews where listing_id =" +id;
            SqlCommand command =new SqlCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Review> reviews = new List<Review>();

            while (dr.Read())
            {
                float listringId = (float)dr["listing_id"];
                float Id = (float)dr["id"];
                string Date = dr["date"].ToString();
                float reviewerId = (float)dr["reviewer_id"];
                string reviewerName= dr["reviewer_name"].ToString();
                string comments = dr["comments"].ToString();
                reviews.Add(new Review(listringId, Id, Date, reviewerId, reviewerName, comments));
            }

            return reviews;
        }

        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {
            // create the command object
            SqlCommand cmd = new SqlCommand();
            // assign the connection to the command object
            cmd.Connection = con;
            // can be Select, Insert, Update, Delete
            cmd.CommandText = CommandSTR;
            // Time to wait for the execution' The default is 30 seconds
            cmd.CommandTimeout = 10;
            // the type of the command, can also be stored procedure
            cmd.CommandType = System.Data.CommandType.Text; 
            return cmd;
        }


        private SqlConnection Connect()
        {
            // read the connection string from the web.config file
            string connectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            // create the connection to the db
            SqlConnection con = new SqlConnection(connectionString);
            // open the database connection
            con.Open();
            return con;
        }

    }
}