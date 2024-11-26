using HotelWebApi_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Controllers
{
    public class CheckAvailabilityController : ApiController
    {
        Rooms room;
        // GET: api/CheckAvailability
        public List<Rooms> Get()
        {
            try {
                room = new Rooms();
                List<Rooms> rmLst = new List<Rooms>();
                rmLst = room.RoomsLoadAll();

                return rmLst;
            }
            catch (Exception ex) {
                ex.ToString();
                return null;
            }
        }

        // GET: api/CheckAvailability/5
        public List<Rooms> Get(string id)
        {
            try {
                room = new Rooms();
                List<Rooms> rmLst = new List<Rooms>();
                rmLst = room.RoomsLoadAllCategoryName(id);

                return rmLst;
            }
            catch (Exception ex) {
                ex.ToString();
                return null;
            }
        }

        // POST: api/CheckAvailability
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CheckAvailability/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CheckAvailability/5
        public void Delete(int id)
        {
        }
    }
}
