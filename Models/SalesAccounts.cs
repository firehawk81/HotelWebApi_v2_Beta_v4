using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesCreator.Models
{
    public class SalesAccounts
    {
        public int CustomersID { get; set; }
        public string AccountName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public decimal Discount { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }

        public decimal Balance { get; set; }

        public List<SalesAccounts> SalesAccountsLoadAll()
        {
            SalesAccounts salesAccount;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "SalesAccountsLoadAll_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<SalesAccounts> lst = new List<SalesAccounts>();
                            while (reader.Read())
                            {

                                salesAccount = new SalesAccounts();
                                salesAccount.AccountName = reader["AccountName"].ToString();
                                salesAccount.Phone = reader["Phone"].ToString();
                                salesAccount.Email = reader["Email"].ToString();
                                salesAccount.Address = reader["Address"].ToString();
                                salesAccount.State = reader["State"].ToString();
                                salesAccount.City = reader["City"].ToString();
                                salesAccount.Discount = Convert.ToDecimal(reader["Discount"]);
                                salesAccount.Country = reader["Country"].ToString();
                                salesAccount.Gender = reader["Gender"].ToString();
                                lst.Add(salesAccount);
                            }
                            return lst;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public SalesAccounts SalesAccountLoadByAccountName(string accountName)
        {
            SalesAccounts customer = new SalesAccounts();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "SalesAccountsLoadByAccountName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@AccountName", accountName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            reader.Read();
                            if (reader.HasRows)
                            {

                                customer.AccountName = reader["AccountName"].ToString();
                                customer.Phone = reader["Phone"].ToString();
                                customer.Email = reader["Email"].ToString();
                                customer.Address = reader["Address"].ToString();
                                customer.State = reader["State"].ToString();
                                customer.City = reader["City"].ToString();
                                customer.Discount = Convert.ToDecimal(reader["Discount"]);
                                customer.Country = reader["Country"].ToString();
                                customer.Gender = reader["Gender"].ToString();

                                customer.Balance = Convert.ToDecimal(reader["Balance"]);
                            }
                            return customer;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
    }
}
