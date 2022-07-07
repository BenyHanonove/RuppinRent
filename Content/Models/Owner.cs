using RuppinRent.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RuppinRent.Models
{
    public class Owner
    {

        int hostId;
        string hostName;
        DateTime hostSince;
        int totalPrice;


        public int HostId { get => hostId; set => hostId = value; }
        public string HostName { get => hostName; set => hostName = value; }
        public DateTime HostSince { get => hostSince; set => hostSince = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }

        public Owner()
        {
        }

        public Owner(int host_id, string host_name, DateTime host_since , int totalPrice)
        {
            this.hostId = host_id;
            this.hostName = host_name;
            this.hostSince = host_since;
            this.totalPrice = totalPrice;
        }




        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public List<Owner> GetOwners()
        {
            DataServices ds = new DataServices();
            List<Owner> owners = ds.GetOwners();
            return owners;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}