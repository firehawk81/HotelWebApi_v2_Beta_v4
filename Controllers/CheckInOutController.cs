using HotelWebApi_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Controllers
{
    public class CheckInOutController : ApiController
    {
        CheckIn checkin;
        int _insertCount = 0;
        // GET: api/CheckInOut
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CheckInOut/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CheckInOut
        public HttpResponseMessage Post([FromBody]Invoices value)
        {
            RoomStatus checkin = new RoomStatus();
            try
            {

                bool _ok = checkin.CheckInOutGuests(value); // id here is used to signifiy if it's Check-In or Check-Out instead of regular id
                if (_ok)
                {

                    _insertCount++;

                    message = Request.CreateResponse(HttpStatusCode.OK, value);
                    // message.Headers.Location = new Uri(Request.RequestUri + value.InvoicesID.ToString());
                }
                return message;
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        HttpResponseMessage message;
        // PUT: api/CheckInOut/isCheckIn
        //public HttpResponseMessage Put([FromBody]Invoices value)
        //{
        //    RoomStatus checkin = new RoomStatus();
        //    try {

        //        bool _ok = checkin.CheckInOutGuests(value); // id here is used to signifiy if it's Check-In or Check-Out instead of regular id
        //        if (_ok) {

        //            _insertCount++;

        //            message = Request.CreateResponse(HttpStatusCode.OK, value);
        //            // message.Headers.Location = new Uri(Request.RequestUri + value.InvoicesID.ToString());
        //        }
        //        return message;
        //    }
        //    catch (Exception ex) {

        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        // DELETE: api/CheckInOut/5
        public void Delete(int id)
        {
        }
    }
}
