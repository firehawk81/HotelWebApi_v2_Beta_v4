using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Controllers
{
    public class ImprestController : ApiController
    {
        // GET: api/Imprest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Imprest/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Imprest
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Imprest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Imprest/5
        public void Delete(int id)
        {
        }
    }
}
