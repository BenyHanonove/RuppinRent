using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

            StringBuilder sb = new StringBuilder();
           
            //string strCommand = "insert into usersHotel (email,password,username) values"+
            //"('"+u.Email+"','"+u.Password+"','"+u.Username+"'); ";

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}','{2}','{3}','{4}','{5}')", u.Email, u.Password, u.Username,u.StringDateJoin(),u.RentTotal,u.CancelTotal);
            String prefix = "INSERT INTO Users " + "([email],[password], [username],[joinDate],[rentTotal],[cancelTotal])";

            string cStr = prefix + sb.ToString();

            SqlCommand command = CreateCommand(cStr, con);
            // Execute
            int numAffected = command.ExecuteNonQuery();

            con.Close();

            return numAffected;
        }

        public List<User> GetUsers()
        {
            SqlConnection con =Connect();
            string commandStr = "select * from Users";
            SqlCommand command = new SqlCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List <User> users = new List<User>();

            while (dr.Read())
            {
                string email = dr["email"].ToString();
                string password = dr["password"].ToString();
                string username = dr["username"].ToString();
                DateTime joindate = Convert.ToDateTime(dr["joinDate"]);
                int rentTotal = int.Parse(dr["rentTotal"].ToString());
                int cancelTotal =int.Parse(dr["cancelTotal"].ToString());
                int id = int.Parse(dr["id"].ToString());
                users.Add(new User(email, password, username,joindate,rentTotal,cancelTotal,id));
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
                long Id =Convert.ToInt64(dr["id"]);
                string Name =dr["name"].ToString();
                string Description =dr["description"].ToString();
                string Picture = dr["picture_url"].ToString();
                string Neighbourhoood = dr["neighbourhood"].ToString();
                string NeighbourhooodOverview = dr["neighborhood_overview"].ToString();
                float Score = float.Parse(dr["review_scores_rating"].ToString());
                string Price = dr["price"].ToString();
                char SuperHost = dr["host_is_superhost"].ToString()[0];
                int MinimumNights = Convert.ToInt32(dr["minimum_nights"]);
                int Maximum_nights = Convert.ToInt32(dr["maximum_nights"]);
                houses.Add(new House(Id, Name, Description, Picture, Neighbourhoood,
                    NeighbourhooodOverview, Score,Price,SuperHost,MinimumNights,Maximum_nights));
            }

            return houses;

        }

        public List<House> GetHousesByName(string name)
        {
            SqlConnection con = Connect();
            string commandStr = "SELECT *"
                                    + " FROM Houses as h"                       
                                    + " WHERE h.name LIKE " + "'%" + name + "%';";
            SqlCommand command = CreateCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<House> houses = new List<House>();

            while (dr.Read())
            {
                long Id = Convert.ToInt64(dr["id"]);
                string Name = dr["name"].ToString();
                string Description = dr["description"].ToString();
                string Picture = dr["picture_url"].ToString();
                string Neighbourhoood = dr["neighbourhood"].ToString();
                string NeighbourhooodOverview = dr["neighborhood_overview"].ToString();
                float Score = float.Parse(dr["review_scores_rating"].ToString());
                string Price = dr["price"].ToString();
                char SuperHost = dr["host_is_superhost"].ToString()[0];
                int MinimumNights = Convert.ToInt32(dr["minimum_nights"]);
                int Maximum_nights = Convert.ToInt32(dr["maximum_nights"]);

                houses.Add(new House(Id, Name, Description, Picture, Neighbourhoood,
                    NeighbourhooodOverview, Score, Price, SuperHost, MinimumNights, Maximum_nights));
            }

            return houses;

        }

        public House GetHouse(long id)
        {
            SqlConnection con = Connect();
            string commandStr = "select * from Houses where id = "+id;
            SqlCommand command = CreateCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            House house = new House();

            while (dr.Read())
            {
                long Id = Convert.ToInt64(dr["id"]);
                string Name = dr["name"].ToString();
                string Description = dr["description"].ToString();
                string Picture = dr["picture_url"].ToString();
                string Neighbourhoood = dr["neighbourhood"].ToString();
                string NeighbourhooodOverview = dr["neighborhood_overview"].ToString();
                float Score = float.Parse(dr["review_scores_rating"].ToString());
                string Price = dr["price"].ToString();
                char SuperHost = dr["host_is_superhost"].ToString()[0];
                int MinimumNights = Convert.ToInt32(dr["minimum_nights"]);
                int Maximum_nights = Convert.ToInt32(dr["maximum_nights"]);

                house = new House(Id, Name, Description, Picture, Neighbourhoood,
                    NeighbourhooodOverview, Score, Price, SuperHost, MinimumNights, Maximum_nights);
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
                float listringId = float.Parse(dr["listing_id"].ToString());
                float Id = float.Parse(dr["id"].ToString());
                string Date = dr["date"].ToString();
                float reviewerId = float.Parse(dr["reviewer_id"].ToString());
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








        public int InsertOrder(Order o)
        {
            SqlConnection con = Connect();

            string commStr = "INSERT INTO Orders (houseId,email,orderdIn,orderFor,orderdOut)" +
            "values("+o.HouseId+",'"+o.Email+"', '"+o.StringDateIn()+"', '"+o.StringDateFor()+"','"+ o.StringDateOut()+"')"; 

            SqlCommand command = CreateCommand(commStr, con);
            // Execute
            int numAffected = command.ExecuteNonQuery();

            con.Close();

            return numAffected;
        }


        public List<Order> GetOrders(string e)
        {
            SqlConnection con = Connect();
            string commandStr = "select * from Orders where email = '"+e+"'";
            SqlCommand command = new SqlCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Order> orders = new List<Order>();

            while (dr.Read())
            {
                string email = dr["email"].ToString();
                long houseId =Convert.ToInt64(dr["houseId"]);
                DateTime orderedIn = Convert.ToDateTime(dr["orderdIn"]);
                DateTime orderFor = Convert.ToDateTime(dr["orderFor"]);
                int id = Convert.ToInt32(dr["id"]);
                DateTime orderdOut = Convert.ToDateTime(dr["orderdOut"]);
                orders.Add(new Order(email, houseId, orderedIn,orderFor,id,orderdOut));
            }

            return orders;
        }


        public List<Order> GetOrders(long Id)
        {
            SqlConnection con = Connect();
            string commandStr = "select * from Orders where houseId = '" + Id + "'";
            SqlCommand command = new SqlCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Order> orders = new List<Order>();

            while (dr.Read())
            {
                string email = dr["email"].ToString();
                long houseId = Convert.ToInt64(dr["houseId"]);
                DateTime orderedIn = Convert.ToDateTime(dr["orderdIn"]);
                DateTime orderFor = Convert.ToDateTime(dr["orderFor"]);
                int id = Convert.ToInt32(dr["id"]);
                DateTime orderdOut = Convert.ToDateTime(dr["orderdOut"]);
                orders.Add(new Order(email, houseId, orderedIn, orderFor, id, orderdOut));
            }

            return orders;
        }


        public int DeleteOrder(string email,long id)
        {
            SqlConnection con = Connect();

            string commStr = "delete from Orders where houseId =" +id +" and email = '"+email+"'";

            SqlCommand command = CreateCommand(commStr, con);
            // Execute
            int numAffected = command.ExecuteNonQuery();

            con.Close();

            return numAffected;
        }


        public int RentUpdatePlus(User u)
        {
            SqlConnection con = Connect();

            string commStr = "UPDATE Users SET rentTotal = RentTotal + 1 where id =" + u.Id;

            SqlCommand command = CreateCommand(commStr, con);
            // Execute
            int numAffected = command.ExecuteNonQuery();

            con.Close();

            return numAffected;
        }

        public int CancelUpdateMinus(User u)
        {
            SqlConnection con = Connect();

            string commStr = "UPDATE Users SET cancelTotal = cancelTotal + 1 where id =" + u.Id;

            SqlCommand command = CreateCommand(commStr, con);
            // Execute
            int numAffected = command.ExecuteNonQuery();

            con.Close();

            return numAffected;
        }

    }
}