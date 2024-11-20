using HotelWebApi_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Controllers
{
    public class ReservationController : ApiController
    {
        HttpResponseMessage message;
        CheckIn checkin;
        int _insertCount = 0;
        Invoices invoice = new Invoices();
        List<Invoices> reservationLst;

        // GET: api/Reservation
        public List<Invoices> Get()
        {
            try {
                reservationLst = invoice.ReservationLoadAll();

                return reservationLst;
            }
            catch (Exception ex) {
                ex.ToString();
                return null;
            }
        }

        // GET: api/Reservation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reservation
        public HttpResponseMessage Post([FromBody]CheckIn value)
        {
             checkin = new CheckIn();
            try {

                bool _ok = checkin.QuickCheckIn(value);
                if (_ok) {

                    _insertCount++;

                    message = Request.CreateResponse(HttpStatusCode.Created, value);
                    message.Headers.Location = new Uri(Request.RequestUri + value.CustomersID.ToString());
                }
                return message;
            }
            catch (Exception ex) {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Reservation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reservation/5
        public void Delete(int id)
        {
        }
    }
}
