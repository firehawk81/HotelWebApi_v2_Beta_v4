using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesCreator.Models
{
    public class BankingDetails
    {
        public int BankDetailsID { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public int AccountNumber { get; set; }
        public string BankBranch { get; set; }

        public bool BankInsert(BankingDetails bank) {
            try {
                using (SqlConnection con=new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd=new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BankInsert_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@AccountName", bank.AccountName));
                        cmd.Parameters.Add(new SqlParameter("@BankName", bank.BankName));
                        cmd.Parameters.Add(new SqlParameter("@AccountNumber", bank.AccountNumber));
                        cmd.Parameters.Add(new SqlParameter("@BankBranch", bank.BankBranch));
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ex.ToString();
                return false;
            }
        }

        public bool BankDetailsUpdateName(BankingDetails bank) {
            try {
                using (SqlConnection con=new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd=new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BankDetailsUpdateName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@AccountName", bank.AccountName));
                        cmd.Parameters.Add(new SqlParameter("@BankName", bank.BankName));
                        cmd.Parameters.Add(new SqlParameter("@AccountNumber", bank.AccountNumber));
                        cmd.Parameters.Add(new SqlParameter("@BankBranch", bank.BankBranch));
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ex.ToString();
                return false;
            }
        }

        public List<BankingDetails> BankingLoadAll() {
            BankingDetails bank;
            try {
                using (SqlConnection con=new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd=new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BankingLoadAll_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader reader=cmd.ExecuteReader()) {
                            List<BankingDetails> lst = new List<BankingDetails>();
                            while (reader.Read()) { 

                                bank = new BankingDetails();
                                bank.AccountName = reader["AccountName"].ToString();
                                bank.BankName = reader["BankName"].ToString();
                                bank.AccountNumber = Convert.ToInt32(reader["AccountNumber"]);
                                bank.BankBranch = reader["BankBranch"].ToString();
                                lst.Add(bank);
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

        public BankingDetails BankingLoadByBankName(string bankName) {
            BankingDetails bank = new BankingDetails();
            try {
                using (SqlConnection con =new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd =new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BankingLoadByBankName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@BankName", bankName);
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            reader.Read();
                            if (reader.HasRows) {

                                bank.AccountName = reader["AccountName"].ToString();
                                bank.BankName = reader["BankName"].ToString();
                                bank.AccountNumber = Convert.ToInt32(reader["AccountNumber"]);
                                bank.BankBranch = reader["BankBranch"].ToString();
                            }
                            return bank;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ex.ToString();
                return null;
            }
        }

        public BankingDetails BankingLoadByBankID(int BankDetailsID) {
            BankingDetails bank = new BankingDetails();
            try {
                using (SqlConnection con =new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd =new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BankingLoadByBankID_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@BankDetailsID", BankDetailsID);
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            reader.Read();
                            if (reader.HasRows) {

                                bank.AccountName = reader["AccountName"].ToString();
                                bank.BankName = reader["BankName"].ToString();
                                bank.AccountNumber = Convert.ToInt32(reader["AccountNumber"]);
                                bank.BankBranch = reader["BankBranch"].ToString();
                            }
                            return bank;
                        }
                    }
                }
            }
            catch (Exception ex) {
                ex.ToString();
                return null;
            }
        }

        public bool BankDetailsDeleteByBankName(string bankName) {
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BankDetailsDeleteByBankName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@BankName", bankName);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ex.ToString();
                return true;
            }
        }

        public bool BankDetailsDeleteAll() {
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BankDetailsDeleteAll_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                ex.ToString();
                return true;
            }
        }
    }
}
