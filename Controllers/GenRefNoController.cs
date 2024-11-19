using HotelWebApi_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApi_v2.Controllers
{
    public class GenRefNoController : ApiController
    {

        GenerateRefNo refNos = new GenerateRefNo(); 
        // GET: api/GenRefNo/5
        public GenerateRefNo Get() {

            GenerateRefNo _ref = new GenerateRefNo();
            _ref = refNos.GenRefNo();
            return _ref;
        }

        // POST: api/GenRefNo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GenRefNo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GenRefNo/5
        public void Delete(int id)
        {
        }
    }
}
