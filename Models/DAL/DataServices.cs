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

        public SqlDataAdapter da;
        public DataTable dt;
        public int InsertUser(User u)
        {
            SqlConnection con = Connect();

            StringBuilder sb = new StringBuilder();
           
            //string strCommand = "insert into usersHotel (email,password,username) values"+
            //"('"+u.Email+"','"+u.Password+"','"+u.Username+"'); ";

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}')", u.Email, u.Password, u.Username,u.StringDateJoin(),u.RentTotal,u.CancelTotal, u.TotalIncome);
            String prefix = "INSERT INTO Users " + "([email],[password], [username],[joinDate],[rentTotal],[cancelTotal], [totalIncome])";

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
                int totalIncome = int.Parse(dr["totalIncome"].ToString());
                users.Add(new User(email, password, username,joindate,rentTotal,cancelTotal,id,totalIncome));
            }

            return users;
        }

        public List<Owner> GetOwners()
        {
            SqlConnection con = Connect();
            //string commandStr = "select MIN(host_id) AS host_id ,host_name,host_since From Houses GROUP BY host_id";
            string commandStr = "  select Houses.id, Houses.host_id,Houses.host_name,Houses.host_since, ISNULL(Orders.totalPrice,0) AS totalPrice, Houses.cancelsNum From Houses LEFT JOIN Orders on Houses.id = Orders.houseId ";


            SqlCommand command = new SqlCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Owner> owners = new List<Owner>();

            while (dr.Read())
            {

                int hostId = int.Parse(dr["host_id"].ToString());
                string hostName = dr["host_name"].ToString() ;
                DateTime hostSince = Convert.ToDateTime(dr["host_since"]);
                int totalPrice = int.Parse(dr["totalPrice"].ToString());
                int totalCancels = int.Parse(dr["cancelsNum"].ToString());
                owners.Add(new Owner(hostId, hostName, hostSince,totalPrice,totalCancels));
            }

            return owners;
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
                int Beds = Convert.ToInt32(dr["beds"]);
                float Latitude = float.Parse(dr["latitude"].ToString());
                float Longitude = float.Parse(dr["longitude"].ToString());
                int CancelsNum = Convert.ToInt32(dr["cancelsNum"].ToString());


                houses.Add(new House(Id, Name, Description, Picture, Neighbourhoood,
                    NeighbourhooodOverview, Score,Price,SuperHost,MinimumNights,Maximum_nights ,
                    Beds , Latitude , Longitude, CancelsNum));
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
                int Beds = Convert.ToInt32(dr["beds"].ToString());
                float Latitude = float.Parse(dr["latitude"].ToString());
                float Longitude = float.Parse(dr["longitude"].ToString());
                int CancelsNum = Convert.ToInt32(dr["cancelsNum"].ToString());

                house = new House(Id, Name, Description, Picture, Neighbourhoood,
                    NeighbourhooodOverview, Score, Price, SuperHost, MinimumNights, Maximum_nights,
                    Beds, Latitude, Longitude, CancelsNum);
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

            string commStr = "INSERT INTO Orders (houseId,email,orderdIn,orderFor,orderdOut,totalPrice,uploadReview)" +
            "values("+o.HouseId+",'"+o.Email+"', '"+o.StringDateIn()+"', '"+o.StringDateFor()+"','"+ o.StringDateOut()+ "','" + o.Price + "',0)"; 

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
                string price = dr["totalPrice"].ToString();
                int uploadReview=Convert.ToInt32(dr["uploadReview"]);

                orders.Add(new Order(email, houseId, orderedIn,orderFor,id,orderdOut, price, uploadReview));
            }

            return orders;
        }


        public List<Order> GetAllOrders()
        {
            SqlConnection con = Connect();
            string commandStr = "select * from Orders";
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
                string price = dr["totalPrice"].ToString();
                int uploadReview = Convert.ToInt32(dr["uploadReview"]);


                orders.Add(new Order(email, houseId, orderedIn, orderFor, id, orderdOut, price, uploadReview));
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
                string price = dr["totalPrice"].ToString();
                int uploadReview = Convert.ToInt32(dr["UploadReview"]);


                orders.Add(new Order(email, houseId, orderedIn, orderFor, id, orderdOut, price, uploadReview));
            }

            return orders;
        }


        public int DeleteOrder(Order order)
        {
            SqlConnection con = Connect();

            string commStr = "delete from Orders where id=" + order.Id;

            SqlCommand command = CreateCommand(commStr, con);
            // Execute
            int numAffected = command.ExecuteNonQuery();

            con.Close();

            return numAffected;
        }


        public int RentUpdatePlus(User u)
        {
            SqlConnection con = Connect();

            string commStr = "UPDATE Users SET rentTotal = RentTotal + 1, totalIncome = " + u.TotalIncome +
                "where id =" + u.Id;

            SqlCommand command = CreateCommand(commStr, con);
            // Execute
            int numAffected = command.ExecuteNonQuery();

            con.Close();

            return numAffected;
        }

        public List<Houseinfo> GetHouseInfo()
        {
            SqlConnection con = Connect();
            //string commandStr = "select MIN(host_id) AS host_id ,host_name,host_since From Houses GROUP BY host_id";
            string commandStr = "select Houses.id, ISNULL(DATEDIFF(day,Orders.orderFor, Orders.orderdOut),0) AS days, Houses.cancelsNum From [dbo].[Houses]  LEFT JOIN Orders on Houses.id = Orders.houseId";


            SqlCommand command = new SqlCommand(commandStr, con);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);           
            List<Houseinfo> h = new List<Houseinfo>();

            while (dr.Read())
            {

                int houseId = Convert.ToInt32(dr["id"]);
                int rentNumOfDays = int.Parse(dr["days"].ToString());
                int totalCancels = int.Parse(dr["cancelsNum"].ToString());
                h.Add(new Houseinfo(houseId, rentNumOfDays, totalCancels));
            }

            return h;
        }

        public int RentUpdatePlus(House h)
        {
            SqlConnection con = Connect();

            string commStr = "UPDATE Houses SET cancelsNum = CancelsNum + 1" +
                "where id =" + h.Id;

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

        public int InsertReview(Review r)
        {
            SqlConnection con = Connect();

            string commStr = "INSERT INTO Reviews (listing_id , id , date ,reviewer_id , reviewer_name , comments )" +
                "values(" + r.ListingId + ",666,'" + r.NowDateTime() + "'," + r.ReviewerId + ",'" + r.ReviewerName + "','" + r.Comments + "')";

            commStr += "UPDATE Orders SET uploadReview =1  where houseId = " + r.ListingId + "and email ='" + r.ReviewerName + "'";

            SqlCommand command = CreateCommand(commStr, con);
            // Execute
            int numAffected = command.ExecuteNonQuery();

            con.Close();

            return numAffected;
        }



        public int DeleteUser(int id)
        {
            SqlConnection con = Connect();

            string commStr = "delete from Users where id =" + id + "";

            SqlCommand command = CreateCommand(commStr, con);
            // Execute
            int numAffected = command.ExecuteNonQuery();

            con.Close();

            return numAffected;
        }



    }


}