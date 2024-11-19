using HotelWebApi_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Controllers
{
    public class RoomDetailsController : ApiController
    {
        Rooms room;
        // GET: api/RoomDetails
        public List<Rooms> Get()
        {
            //room = new Rooms();
            //List<Rooms> roomLst = new List<Rooms>();
            //roomLst = room.RoomsLoadAll();

            return null;
        }

        // GET: api/RoomDetails/5
        public Rooms Get(string id)
        {
            room = new Rooms();
            Rooms rm = new Rooms();
            rm = room.RoomDetailsByCategoryName(id);

            return rm;
        }

        // POST: api/RoomDetails
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RoomDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RoomDetails/5
        public void Delete(int id)
        {
        }
    }
}
