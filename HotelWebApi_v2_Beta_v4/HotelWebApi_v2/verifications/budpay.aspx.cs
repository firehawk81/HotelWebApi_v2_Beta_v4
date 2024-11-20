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
    public partial class budpay : System.Web.UI.Page
    {
        //FlutterWaveApi verifyPay = new FlutterWaveApi("FLWSECK_TEST-b9eb6f15b65178a1b95243f6cea2d344-X");
        FlutterWaveApi verifyPay = new FlutterWaveApi("sk_test_rvuppkyqtiwydtm9581qt8rnpyqre8wsonihppg"); //BudPay
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string _refNo = Request.QueryString["reference"];

                TransactionReponse verr = new TransactionReponse();

                verr = await verifyPay.VerifyPayment(_refNo);
                if (verr.status == "true") {
                    pRefNo.InnerText = _refNo.ToUpper();
                    //Response.Redirect("www.google.com",false);
                }
            }
        }
    }
}