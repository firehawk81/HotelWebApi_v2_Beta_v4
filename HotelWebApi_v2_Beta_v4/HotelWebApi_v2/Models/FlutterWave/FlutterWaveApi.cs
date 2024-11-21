using HotelWebApi_v2.Models.FlutterWave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HotelWebApi_v2.Models.Models
{
    public class FlutterWaveApi
    {
        protected string _serviceKey;
        public FlutterWaveApi(string ServiceKey)
        {
            _serviceKey = ServiceKey;
        }

        private async Task<TransactionReponse> MakePayment(TransactRequest request)
        {
            string endpoint = "/v3/payments";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.flutterwave.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(_serviceKey))
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _serviceKey);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _serviceKey);

                var payload = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endpoint, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TransactionReponse resp = JsonConvert.DeserializeObject<TransactionReponse>(content);

                    if (resp.status == "successful")
                    {

                        // Insert Customers information here 
                        var submitData = "{name: John, Phone: 07032499237, email: info@9appsoft.com}";
                        // Insert Customers information here

                    }
                    return resp;
                }
                else
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TransactionReponse>(content);
                }
            }
        }

        public async Task<TransactionReponse> VerifyPayment(string transactiondId)
        {
            //https://api.budpay.com/api/v2/transaction/verify/reference
            
            string endpoint = $"/v3/transactions/"+ transactiondId + "/verify";
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("https://api.flutterwave.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(_serviceKey))
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _serviceKey);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _serviceKey);

                //var payload = JsonConvert.SerializeObject(request);
                //var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode) {
                    string content = await response.Content.ReadAsStringAsync();
                    TransactionReponse resp = JsonConvert.DeserializeObject<TransactionReponse>(content);

                    
                    return resp;
                }
                else {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TransactionReponse>(content);
                }
            }
        }



        public TransactionReponse Initialize(TransactRequest request)
        {
            return Task.Run(() => MakePayment(request)).Result;
        }
        public TransactionReponse Verify(string transactionId)
        {
            return Task.Run(() => VerifyPayment(transactionId)).Result;
        }
    }
}