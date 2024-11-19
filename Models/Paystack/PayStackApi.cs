using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using PayStack.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using static PayStack.Net.Charge;

namespace HotelWebApi_v2.Models.Paystack
{
    public interface IPayStackApi
    {
        ISubAccountApi SubAccounts { get; }
        ITransactionsApi Transactions { get; }
        ICustomersApi Customers { get; }
        ISettlementsApi Settlements { get; }
        ITransfersApi Transfers { get; }
    }

    public class Rootobject
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public long id { get; set; }
        public string domain { get; set; }
        public string status { get; set; }
        public string reference { get; set; }
        public object receipt_number { get; set; }
        public int amount { get; set; }
        public object message { get; set; }
        public string gateway_response { get; set; }
        public DateTime paid_at { get; set; }
        public DateTime created_at { get; set; }
        public string channel { get; set; }
        public string currency { get; set; }
        public string ip_address { get; set; }
        public string metadata { get; set; }
        public Log log { get; set; }
        public int fees { get; set; }
        public object fees_split { get; set; }
        public Authorization authorization { get; set; }
        public Customer customer { get; set; }
        public object plan { get; set; }
        public Split split { get; set; }
        public object order_id { get; set; }
        public DateTime paidAt { get; set; }
        public DateTime createdAt { get; set; }
        public int requested_amount { get; set; }
        public object pos_transaction_data { get; set; }
        public object source { get; set; }
        public object fees_breakdown { get; set; }
        public object connect { get; set; }
        public DateTime transaction_date { get; set; }
        public Plan_Object plan_object { get; set; }
        public Subaccount subaccount { get; set; }
    }

    public class Log
    {
        public int start_time { get; set; }
        public int time_spent { get; set; }
        public int attempts { get; set; }
        public int errors { get; set; }
        public bool success { get; set; }
        public bool mobile { get; set; }
        public object[] input { get; set; }
        public History[] history { get; set; }
    }

    public class History
    {
        public string type { get; set; }
        public string message { get; set; }
        public int time { get; set; }
    }

    public class Authorization
    {
        public string authorization_code { get; set; }
        public string bin { get; set; }
        public string last4 { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public string channel { get; set; }
        public string card_type { get; set; }
        public string bank { get; set; }
        public string country_code { get; set; }
        public string brand { get; set; }
        public bool reusable { get; set; }
        public string signature { get; set; }
        public object account_name { get; set; }
    }

    public class Customer
    {
        public int id { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public string email { get; set; }
        public string customer_code { get; set; }
        public object phone { get; set; }
        public object metadata { get; set; }
        public string risk_action { get; set; }
        public object international_format_phone { get; set; }
    }

    public class Split
    {
    }

    public class Plan_Object
    {
    }

    public class Subaccount
    {
    }

    public class TransactionReponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }

    }
    
    public class PayStackApi : IPayStackApi
    {
        private readonly HttpClient _client;
        private readonly string secretKey = "sk_test_97249a9eba3c12f6d2e388aa50679aba293f769c";
        public PayStackApi(string secretKey)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _client = new HttpClient { BaseAddress = new Uri("https://api.paystack.co/") };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secretKey);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Transactions = new TransactionsApi(this);
            //Customers = new CustomersApi(this);
            //SubAccounts = new SubAccountApi(this);
            //Settlements = new SettlementsApi(this);
            //Miscellaneous = new MiscellaneousApi(this);
            //Transfers = new TransfersApi(this);
            //Charge = new ChargeApi(this);
        }

        public static JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
        };

        public ISubAccountApi SubAccounts { get; }

        public ITransactionsApi Transactions { get; }

        public ICustomersApi Customers { get; }

        public ISettlementsApi Settlements { get; }

        public IMiscellaneousApi Miscellaneous { get; }

        public ITransfersApi Transfers { get; }

        public IChargeApi Charge { get; }


        [Obsolete("Use PayStack.Net.Miscellaneous.ResolveCardBin(cardBin) instead.")]
        public ResolveCardBinResponse ResolveCardBin(string cardBin) => Miscellaneous.ResolveCardBin(cardBin);

        #region Utility Methods
        private async Task<TransactionReponse> VerifyPayment(string reference)
        {
            //"https://api.paystack.co/transaction/verify/{reference}"
            string endpoint = $"/transaction/verify/{reference}";
            using (var client = new HttpClient()) {

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri("https://api.paystack.co/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(secretKey))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secretKey);
                
                //var payload = JsonConvert.SerializeObject(request);
                //var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode) {
                    string content = await response.Content.ReadAsStringAsync();
                    TransactionReponse resp = JsonConvert.DeserializeObject<TransactionReponse>(content);


                    if (resp.status == "success") {

                        // Insert Customers information here 
                        var submitData = "{name: John, Phone: 07032499237, email: info@9appsoft.com}";
                        
                        // Insert Customers information here

                    }
                    return resp;
                }
                else {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TransactionReponse>(content);
                }
            }
        }

        private string PrepareRequest<T>(T request)
        {
            (request as IPreparable)?.Prepare();

            var requestBody = JsonConvert.SerializeObject(request, Formatting.Indented, SerializerSettings);
            return requestBody;
        }

        public TR Post<TR, T>(string relativeUrl, T request) where TR : IApiResponse
        {
            var rawJson = _client.PostAsync(
                    relativeUrl.TrimStart('/'),
                    new StringContent(PrepareRequest(request))
                ).Result.Content.ReadAsStringAsync().Result;

            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        private static TR ParseAndResolveMetadata<TR>(ref string rawJson) where TR : IApiResponse
        {
            var jo = JObject.Parse(rawJson);
            var data = jo["data"];
            if (data != null && !(data is JArray) && data["metadata"] != null)
            {
                var metadata = data["metadata"];
                jo["data"]["metadata"] = JsonConvert.DeserializeObject<JObject>(metadata.ToString());
            }

            rawJson = jo.ToString();

            var response = JsonConvert.DeserializeObject<TR>(rawJson);

            if (typeof(IHasRawResponse).IsAssignableFrom(typeof(TR)))
                (response as IHasRawResponse).RawJson = rawJson;

            return response;
        }

        public TR Put<TR, T>(string relativeUrl, T request) where TR : IApiResponse
        {
            var rawJson = _client.PutAsync(
                    relativeUrl.TrimStart('/'),
                    new StringContent(PrepareRequest(request))
                ).Result.Content.ReadAsStringAsync().Result;

            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        public TR Get<TR, T>(string relativeUrl, T request)
            where TR : class, IApiResponse
        {
            var preparable = request as IPreparable;

            var queryString = "";
            if (request != null)
                queryString = "?" + request.ToQueryString();

            if (preparable != null)
                preparable.Prepare();

            var rawJson = _client.GetAsync(relativeUrl.TrimStart('/') + queryString).Result.Content.ReadAsStringAsync().Result;
            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        public TR Get<TR>(string relativeUrl) where TR : IApiResponse
        {
            var rawJson = _client.GetAsync(relativeUrl.TrimStart('/')).Result.Content.ReadAsStringAsync().Result;
            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        #endregion
    }
}