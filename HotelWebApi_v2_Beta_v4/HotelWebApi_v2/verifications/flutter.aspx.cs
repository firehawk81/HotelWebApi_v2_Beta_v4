using HotelWebApi_v2.Models.FlutterWave;
using HotelWebApi_v2.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWebApi_v2.verifications
{
    public partial class flutter : System.Web.UI.Page
    {
        
        //FlutterWaveApi verifyPay = new FlutterWaveApi("FLWSECK_TEST-b9eb6f15b65178a1b95243f6cea2d344-X");
        FlutterWaveApi verifyPay = new FlutterWaveApi("FLWSECK_TEST-b9eb6f15b65178a1b95243f6cea2d344-X"); //BudPay
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string _status = Request.QueryString["status"];
                string _tx_ref = Request.QueryString["tx_ref"];
                string _transaction_id = Request.QueryString["transaction_id"];

                TransactionReponse verr = new TransactionReponse();

                verr = await verifyPay.VerifyPayment(_transaction_id);      // status=successful&tx_ref=txref-DI0NzMx13&transaction_id=8206200
                if (verr.status == "successful") {
                    pRefNo.InnerText = _transaction_id.ToUpper();
                    //Response.Redirect("www.google.com",false);
                }
            }
        }
    }
}