using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWebApi_v2.Models
{
    public class CheckIn
    {

        public int CustomersID { get; set; }
        //public string RefNo { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; }
        public string AccountName { get; set; }
        public string SalesAccountName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public string FullName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public decimal Discount { get; set; }
        public string Country { get; set; }


        public string Gender { get; set; }
        public string IdentityType { get; set; }
        public string PaymentMethod { get; set; }
        // ---------------------------------
        public int NoOfRooms { get; set; }
        public int Nights { get; set; }
        public string BookingDate { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        //-----------------------------------
        public string RoomName { get; set; }
        public string CategoryName { get; set; }
        //----------------------------------
        //public decimal Balance { get; set; }

        //-----------------------------------
        public int AccountNumber { get; set; }
        public string LoginName { get; set; }
        //-----------------------------------
        public decimal TransactionTotal { get; set; }
        public decimal AmountPaid { get; set; }
        //----------------------------------
        public string TransactDate { get; set; }
        public string Details { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public string RefNo { get; set; }
        public decimal Balance { get; set; }

        // POS Instance Variables
        public string SalesPointName { get; set; }
        public int QTY { get; set; }
        // POS Instance Variables

        // Check-In or Reservation
        public bool Paid { get; set; }
        public bool IsReservation { get; set; }

        public bool MakeReservation(CheckIn checkIn) {
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = "Data Source =.\\MSSQLSERVER2012;Initial Catalog=Ibomwater_db;User ID=Ibom_user;Password=@Down1234#;Integrated Security=False";
                                         //"Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "CheckInReservation_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        //cmd.Parameters.Add(new SqlParameter("@RefNo", checkIn.RefNo));
                        //cmd.Parameters.Add(new SqlParameter("@Adults", checkIn.Adults));
                        //cmd.Parameters.Add(new SqlParameter("@Children", checkIn.Children));
                        //cmd.Parameters.Add(new SqlParameter("@Amount", checkIn.Amount));
                        //cmd.Parameters.Add(new SqlParameter("@Title", checkIn.Title));
                        cmd.Parameters.Add(new SqlParameter("@Phone", checkIn.Phone));
                        cmd.Parameters.Add(new SqlParameter("@Email", checkIn.Email));
                        //cmd.Parameters.Add(new SqlParameter("@FullName", checkIn.FullName));
                        cmd.Parameters.Add(new SqlParameter("@Gender", checkIn.Gender));
                        cmd.Parameters.Add(new SqlParameter("@IdentityTYpe", checkIn.IdentityType));
                        cmd.Parameters.Add(new SqlParameter("@PaymentMethod", checkIn.PaymentMethod));
                        // ---------------------------------
                        //cmd.Parameters.Add(new SqlParameter("@NoOfRoom", checkIn.NoOfRoom));
                        //cmd.Parameters.Add(new SqlParameter("@Nights", checkIn.Nights));
                        //cmd.Parameters.Add(new SqlParameter("@BookingDate", checkIn.BookingDate));
                        //cmd.Parameters.Add(new SqlParameter("@CheckIn", checkIn.CheckIn));
                        //cmd.Parameters.Add(new SqlParameter("@CheckOut", checkIn.CheckOut));
                        // ---------------------------------
                        //cmd.Parameters.Add(new SqlParameter("@RoomName", checkIn.RoomName));
                        //cmd.Parameters.Add(new SqlParameter("@CategoryName", checkIn.CategoryName));
                        //cmd.Parameters.Add(new SqlParameter("@LoginName", checkIn.LoginName));
                        // ---------------------------------
                        cmd.Parameters.Add(new SqlParameter("@AccountName", checkIn.AccountName));
                        cmd.Parameters.Add(new SqlParameter("@Address", checkIn.Address));
                        cmd.Parameters.Add(new SqlParameter("@State", checkIn.State));
                        cmd.Parameters.Add(new SqlParameter("@City", checkIn.City));
                        cmd.Parameters.Add(new SqlParameter("@Discount", checkIn.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Country", checkIn.Country));
                        // ---------------------------------
                        //cmd.Parameters.Add(new SqlParameter("@Balance", checkIn.Balance));
                        cmd.Parameters.Add(new SqlParameter("@AccountNumber", checkIn.AccountNumber));
                        // ---------------------------------
                        //cmd.Parameters.Add(new SqlParameter("@TransactionDate", checkIn.TransactionDate));
                        //cmd.Parameters.Add(new SqlParameter("@Details", checkIn.Details));
                        //cmd.Parameters.Add(new SqlParameter("@Credit", checkIn.Credit));
                        cmd.Parameters.Add(new SqlParameter("@TransactDate", checkIn.TransactDate));
                        cmd.Parameters.Add(new SqlParameter("@Debit", checkIn.AmountPaid));

                        cmd.Parameters.Add(new SqlParameter("@SalesPointName", checkIn.SalesPointName));
                        cmd.Parameters.Add(new SqlParameter("@QTY", checkIn.QTY));

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
        public bool QuickCheckIn(CheckIn checkIn) {
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = "Data Source =.\\MSSQLSERVER2012;Initial Catalog=Ibomwater_db;User ID=Ibom_user;Password=@Down1234#;Integrated Security=False";

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "CheckInReservation_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        //cmd.Parameters.Add(new SqlParameter("@RefNo", checkIn.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@Adults", checkIn.Adults));
                        cmd.Parameters.Add(new SqlParameter("@Children", checkIn.Children));
                        //cmd.Parameters.Add(new SqlParameter("@Amount", checkIn.Amount));
                        cmd.Parameters.Add(new SqlParameter("@Title", checkIn.Title));
                        cmd.Parameters.Add(new SqlParameter("@FullName", checkIn.AccountName));
                        cmd.Parameters.Add(new SqlParameter("@IdentityType", checkIn.IdentityType));
                        cmd.Parameters.Add(new SqlParameter("@PaymentMethod", checkIn.PaymentMethod));
                        //---------------------------------
                        cmd.Parameters.Add(new SqlParameter("@NoOfRooms", checkIn.NoOfRooms));
                        cmd.Parameters.Add(new SqlParameter("@Nights", checkIn.Nights));
                        // cmd.Parameters.Add(new SqlParameter("@BookingDate", checkIn.BookingDate));
                        cmd.Parameters.Add(new SqlParameter("@CheckInDate", checkIn.CheckInDate));
                        cmd.Parameters.Add(new SqlParameter("@CheckOutDate", checkIn.CheckOutDate));
                        // ---------------------------------
                        //cmd.Parameters.Add(new SqlParameter("@RoomName", checkIn.RoomName));
                        cmd.Parameters.Add(new SqlParameter("@CategoryName", checkIn.CategoryName));
                        // ---------------------------------
                        cmd.Parameters.Add(new SqlParameter("@AccountName", checkIn.AccountName));
                        cmd.Parameters.Add(new SqlParameter("@SalesAccountName", checkIn.SalesAccountName));
                        cmd.Parameters.Add(new SqlParameter("@Phone", checkIn.Phone));
                        cmd.Parameters.Add(new SqlParameter("@Email", checkIn.Email));
                        cmd.Parameters.Add(new SqlParameter("@Address", checkIn.Address));
                        cmd.Parameters.Add(new SqlParameter("@State", checkIn.State));
                        cmd.Parameters.Add(new SqlParameter("@City", checkIn.City));
                        cmd.Parameters.Add(new SqlParameter("@Discount", checkIn.Discount));
                        cmd.Parameters.Add(new SqlParameter("@Country", checkIn.Country));
                        cmd.Parameters.Add(new SqlParameter("@Gender", checkIn.Gender));
                        // ---------------------------------
                        //cmd.Parameters.Add(new SqlParameter("@Balance", checkIn.Balance));
                        cmd.Parameters.Add(new SqlParameter("@AccountNumber", checkIn.AccountNumber));
                        cmd.Parameters.Add(new SqlParameter("@LoginName", checkIn.LoginName));
                        // ---------------------------------
                        cmd.Parameters.Add(new SqlParameter("@TransactionTotal", checkIn.TransactionTotal));
                        cmd.Parameters.Add(new SqlParameter("@AmountPaid", checkIn.AmountPaid));
                        // ---------------------------------
                        cmd.Parameters.Add(new SqlParameter("@TransactDate", checkIn.TransactDate));
                        cmd.Parameters.Add(new SqlParameter("@Details", checkIn.Details));
                        cmd.Parameters.Add(new SqlParameter("@Credit", checkIn.Credit));
                        cmd.Parameters.Add(new SqlParameter("@Debit", checkIn.Debit));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", checkIn.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@RoomName", checkIn.RoomName));
                        //cmd.Parameters.Add(new SqlParameter("@Balance", checkIn.Balance));

                        cmd.Parameters.Add(new SqlParameter("@SalesPointName", checkIn.SalesPointName));
                        //cmd.Parameters.Add(new SqlParameter("@QTY", checkIn.QTY));

                        cmd.Parameters.Add(new SqlParameter("@Paid", checkIn.Paid));
                        cmd.Parameters.Add(new SqlParameter("@IsReservation", checkIn.IsReservation));

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
    }
}