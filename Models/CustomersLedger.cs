using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesCreator.Models
{
    public class CustomersLedger
    {

        public int InvoicesID { get; set; }
        public string AccountName { get; set; }
        public decimal AmountPaid { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public decimal Balance { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal Rate { get; set; }
        public string TransactDate { get; set; }
        public int Rooms { get; set; }
        public int Nights { get; set; }
        public string Details { get; set; }
        public string PaymentMethod { get; set; }
        public string RefNo { get; set; }
        public string LoginName { get; set; }
        public string UserFullName { get; set; }
        //public string UserLastName { get; set; }

        public List<CustomersLedger> CustomersLedgerByRefNo(string refNo)
        {
            CustomersLedger invoice;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomersInvoices_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@RefNo", refNo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            
                            List<CustomersLedger> lst = new List<CustomersLedger>();
                            while (reader.Read())
                            {

                                invoice = new CustomersLedger();
                                invoice.AccountName = reader["AccountName"].ToString();
                                invoice.Phone = reader["Phone"].ToString();
                                invoice.Address = reader["Address"].ToString();
                                invoice.CheckInDate = reader["CheckIn"].ToString();
                                invoice.CheckOutDate = reader["CheckOut"].ToString();
                                invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                                invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                                invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                                invoice.Rate = Convert.ToDecimal(reader["Rate"]);
                                invoice.TransactDate = reader["TransactDate"].ToString();
                                invoice.Rooms = Convert.ToInt32(reader["NoOfRooms"]);
                                invoice.Nights = Convert.ToInt32(reader["Nights"]);
                                invoice.Details = reader["Details"].ToString();
                                invoice.PaymentMethod = reader["PaymentMethod"].ToString();
                                invoice.UserFullName = reader["UserFullName"].ToString();
                                invoice.RefNo = reader["RefNO"].ToString();
                                lst.Add(invoice);
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
        public List<CustomersLedger> CustomersLedgerByName(string accountName)
        {
            CustomersLedger ledger;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomersLedgerByAccountName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@AccountName", accountName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<CustomersLedger> lst = new List<CustomersLedger>();
                            while (reader.Read())
                            {

                                ledger = new CustomersLedger();
                                ledger.AccountName = reader["AccountName"].ToString();
                                ledger.Phone = reader["Phone"].ToString();
                                ledger.Address = reader["Address"].ToString();
                                ledger.CheckInDate = reader["CheckIn"].ToString();
                                ledger.CheckOutDate = reader["CheckOut"].ToString();
                                ledger.Balance = Convert.ToDecimal(reader["Balance"]);
                                ledger.Credit = Convert.ToDecimal(reader["Credit"]);
                                ledger.Debit = Convert.ToDecimal(reader["Debit"]);
                                ledger.Rate = Convert.ToDecimal(reader["Rate"]);
                                ledger.TransactDate = reader["TransactDate"].ToString();
                                ledger.Rooms = Convert.ToInt32(reader["NoOfRooms"]);
                                ledger.Nights = Convert.ToInt32(reader["Nights"]);
                                ledger.Details = reader["Details"].ToString();
                                //invoice.PaymentMethod = reader["PaymentMethod"].ToString();
                                //invoice.UserFullName = reader["UserFullName"].ToString();
                                //invoice.RefNo = reader["RefNO"].ToString();
                                lst.Add(ledger);
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

    }
}
