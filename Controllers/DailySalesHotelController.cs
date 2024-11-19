using HotelWebApi_v2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Controllers
{
    public class DailySalesHotelController : ApiController
    {
        Invoices invoice;
        List<Invoices> invoiceLst;
        // GET: api/DailySalesHotel
        public List<Invoices> Get()
        {
            invoice = new Invoices();
            invoiceLst = new List<Invoices>();

            invoiceLst = invoice.CustomersInvoicesLoadAll_web();
            return invoiceLst;

        }

        // GET: api/DailySalesHotel/5
        public string Get(int id)
        {
            return "value";
        }

        CheckIn checkin;
        int _insertCount = 0;
        // POST: api/DailySalesHotel
        public HttpResponseMessage Post([FromBody]CheckIn value)
        {
            checkin = new CheckIn();
            try {

                bool _ok = checkin.QuickCheckIn(value);
                if (_ok) {

                    _insertCount++;
                }

                var message = Request.CreateResponse(HttpStatusCode.Created, value);
                message.Headers.Location = new Uri(Request.RequestUri + value.CustomersID.ToString());
                return message;

            }
            catch (Exception ex) {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/DailySalesHotel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DailySalesHotel/5
        public void Delete(int id)
        {
        }
    }
}
