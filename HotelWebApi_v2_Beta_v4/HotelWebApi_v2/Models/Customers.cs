using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesCreator.Models
{
    public class Customers
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

        public List<Customers> CustomersLoadAll() {
            Customers customer;
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomersLoadAll_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            List<Customers> lst = new List<Customers>();
                            while (reader.Read()) {

                                customer = new Customers();
                                customer.AccountName = reader["AccountName"].ToString();
                                customer.Phone = reader["Phone"].ToString();
                                customer.Email = reader["Email"].ToString();
                                customer.Address = reader["Address"].ToString();
                                customer.State = reader["State"].ToString();
                                customer.City = reader["City"].ToString();
                                customer.Discount = Convert.ToDecimal(reader["Discount"]);
                                customer.Country = reader["Country"].ToString();
                                customer.Gender = reader["Gender"].ToString();
                                lst.Add(customer);
                            }
                            return lst;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ex.ToString();
                return null;
            }
        }

        public Customers CustomersLoadByAccountName(string accountName) {
            Customers customer = new Customers();
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomersLoadByAccountName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@AccountName", accountName);
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            
                            reader.Read();
                            if (reader.HasRows) {
                                
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
            catch (Exception ex) {
                ex.ToString();
                return null;
            }
        }
    }
}
