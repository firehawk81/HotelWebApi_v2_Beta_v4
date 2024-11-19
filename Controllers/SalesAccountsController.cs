using HotelWebApi_v2.Models;
using SidesCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Controllers
{
    public class SalesAccountsController : ApiController
    {
        SalesAccounts salesAcoount;
        List<SalesAccounts> salesAcoountLst;
        // GET: api/SalesAccounts
        public List<SalesAccounts> Get()
        {

            salesAcoount = new SalesAccounts();
            salesAcoountLst = new List<SalesAccounts>();

            salesAcoountLst = salesAcoount.SalesAccountsLoadAll();
            return salesAcoountLst;
        }

        // GET: api/SalesAccounts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SalesAccounts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SalesAccounts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SalesAccounts/5
        public void Delete(int id)
        {
        }
    }
}
