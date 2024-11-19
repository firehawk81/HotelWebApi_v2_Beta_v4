using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebApi_v2.Models
{
    public class GenerateRefNo
    {
        public string RefNo { get; set; }

        GenerateRefNo refNos;
        public GenerateRefNo GenRefNo() {
            refNos = new GenerateRefNo(); 
        
            int _refNo;
            Random _r = new Random();

            _refNo = _r.Next(111111111, 999999999);
            refNos.RefNo = "Ref-" + _refNo.ToString() + "-e";

            return refNos;
        }
    }
}