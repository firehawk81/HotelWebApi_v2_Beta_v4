﻿using HotelWebApi_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Controllers
{
    public class RoomsController : ApiController
    {
        Rooms room;
        List<Rooms> roomLst;
        // GET: api/Rooms
        public List<Rooms> Get()
        {
            try {

                room = new Rooms();
                roomLst = room.RoomsLoadAll();

                return roomLst;
            }
            catch (Exception ex) {
                ex.ToString();
                return null;
            }
        }

        // GET: api/Rooms/5
        public List<Rooms> Get(string id) // Rooms Availability for Admin page
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

        // POST: api/Rooms
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
        }
    }
}
