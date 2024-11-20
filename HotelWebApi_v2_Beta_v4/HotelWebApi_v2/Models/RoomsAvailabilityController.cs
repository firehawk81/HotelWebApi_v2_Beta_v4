using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Models
{
    public class RoomsAvailabilityController : ApiController
    {
        Rooms room;
        // GET: api/RoomsAvailability
        public List<Rooms> Get()
        {
            room = new Rooms();
            List<Rooms> roomLst = new List<Rooms>();
            roomLst = room.RoomsLoadAll();

            return roomLst;
        }

        // GET: api/RoomsAvailability/5
        public List<Rooms> Get(string id)
        {
            room = new Rooms();
            List<Rooms> roomLst = new List<Rooms>();
            roomLst = room.RoomsLoadAllCategoryName(id);

            return roomLst;
        }

        // POST: api/RoomsAvailability
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RoomsAvailability/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RoomsAvailability/5
        public void Delete(int id)
        {
        }
    }
}
