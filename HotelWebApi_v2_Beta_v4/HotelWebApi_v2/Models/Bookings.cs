using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesCreator.Models
{
    public class Bookings
    {        
        public int Adults { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string BookingDate { get; set; }
        public int BookingID { get; set; }
        public int BookingsDetailsID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public int Children { get; set; }
        public string Email { get; set; }
        public int FloorsID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string IdentityType { get; set; }
        public string LoginName { get; set; }
        public int Nights { get; set; }
        public string NightText { get; set; }
        public int NoOfRooms { get; set; }
        public string PaymentMethod { get; set; }
        public string Phone { get; set; }
        public string RefNo { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int RoomStatusID { get; set; }
        public string Title { get; set; }
        public decimal Total { get; set; }
        public int UserAccessID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        Bookings booking;
        public List<Bookings> BookingsLoadAll() {
            
            try {
                using (SqlConnection con=new SqlConnection())  {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd=new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BookingLoadAll_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader reader=cmd.ExecuteReader()) {
                            List<Bookings> lst = new List<Bookings>();
                            while (reader.Read()) {
                                booking = new Bookings();

                                booking.Adults = Convert.ToInt32(reader["Adults"]);
                                booking.Amount = Convert.ToDecimal(reader["Amount"]);
                                //booking.Balance = Convert.ToDecimal(reader["Balance"]);
                                booking.BookingDate = reader["BookingDate"].ToString();
                                //booking.BookingID = Convert.ToInt32(reader["BookingID"]);
                                //booking.BookingsDetailsID = Convert.ToInt32(reader["BookingsDetailsID"]);
                                //booking.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                                //booking.CategoryName = reader["CategoryName"].ToString();
                                booking.CheckInDate = reader["CheckIn"].ToString();
                                booking.CheckOutDate = reader["CheckOut"].ToString();
                                booking.Children = Convert.ToInt32(reader["Children"]);
                                booking.Email = reader["Email"].ToString();
                                //booking.FloorsID = Convert.ToInt32(reader["FloorsID"]);
                                booking.FullName = reader["FullName"].ToString();
                                //booking.Gender = reader["Gender"].ToString();
                                //booking.IdentityType = reader["IdentityType"].ToString();
                                booking.LoginName = reader["LoginName"].ToString();
                                booking.Nights = Convert.ToInt32(reader["Nights"]);
                                //booking.NightText = reader["NightText"].ToString();
                                booking.NoOfRooms = Convert.ToInt32(reader["NoOfRooms"]);
                                booking.PaymentMethod = reader["PaymentMethod"].ToString();
                                booking.Phone = reader["Phone"].ToString();
                                booking.RefNo = reader["RefNo"].ToString();
                                //booking.RoomID = Convert.ToInt32(reader["RoomID"]);
                                booking.RoomName = reader["RoomName"].ToString();
                                //booking.RoomStatusID = Convert.ToInt32(reader["RoomStatusID"]);
                                booking.Title = reader["Title"].ToString();
                               // booking.Total = Convert.ToDecimal(reader["Total"]);
                                //booking.UserAccessID = Convert.ToInt32(reader["UserAccessID"]);
                                booking.UserFirstName = reader["UsersFullName"].ToString();
                                //booking.UserLastName = reader["UserLastName"].ToString();
                                lst.Add(booking);
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

        public List<Bookings> BookingsLoadBySalesPersonAndDate(string loginName, string fromDate, string toDate) {
            
            try {
                using (SqlConnection con=new SqlConnection())  {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd=new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BookingMadeLoadAllByFromAndToDate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@LoginName", loginName);
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);

                        using (SqlDataReader reader=cmd.ExecuteReader()) {
                            List<Bookings> lst = new List<Bookings>();
                            while (reader.Read()) {
                                booking = new Bookings();

                                booking.Adults = Convert.ToInt32(reader["Adults"]);
                                booking.Amount = Convert.ToDecimal(reader["Amount"]);
                                //booking.Balance = Convert.ToDecimal(reader["Balance"]);
                                booking.BookingDate = reader["BookingDate"].ToString();
                                //booking.BookingID = Convert.ToInt32(reader["BookingID"]);
                                //booking.BookingsDetailsID = Convert.ToInt32(reader["BookingsDetailsID"]);
                                //booking.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                                //booking.CategoryName = reader["CategoryName"].ToString();
                                booking.CheckInDate = reader["CheckIn"].ToString();
                                booking.CheckOutDate = reader["CheckOut"].ToString();
                                booking.Children = Convert.ToInt32(reader["Children"]);
                                booking.Email = reader["Email"].ToString();
                                //booking.FloorsID = Convert.ToInt32(reader["FloorsID"]);
                                booking.FullName = reader["FullName"].ToString();
                                //booking.Gender = reader["Gender"].ToString();
                                //booking.IdentityType = reader["IdentityType"].ToString();
                                booking.LoginName = reader["LoginName"].ToString();
                                booking.Nights = Convert.ToInt32(reader["Nights"]);
                                //booking.NightText = reader["NightText"].ToString();
                                booking.NoOfRooms = Convert.ToInt32(reader["NoOfRooms"]);
                                booking.PaymentMethod = reader["PaymentMethod"].ToString();
                                booking.Phone = reader["Phone"].ToString();
                                booking.RefNo = reader["RefNo"].ToString();
                                //booking.RoomID = Convert.ToInt32(reader["RoomID"]);
                                booking.RoomName = reader["RoomName"].ToString();
                                //booking.RoomStatusID = Convert.ToInt32(reader["RoomStatusID"]);
                                booking.Title = reader["Title"].ToString();
                               // booking.Total = Convert.ToDecimal(reader["Total"]);
                                //booking.UserAccessID = Convert.ToInt32(reader["UserAccessID"]);
                                booking.UserFirstName = reader["UsersFullName"].ToString();
                                //booking.UserLastName = reader["UserLastName"].ToString();
                                lst.Add(booking);
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

        public List<Bookings> BookingsLoadByByGuestName(string fullName) {
            
            try {
                using (SqlConnection con=new SqlConnection())  {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd=new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BookingMadeLoadAllByGuestName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@FullName", fullName);

                        using (SqlDataReader reader=cmd.ExecuteReader()) {
                            List<Bookings> lst = new List<Bookings>();
                            while (reader.Read()) {
                                booking = new Bookings();

                                booking.Adults = Convert.ToInt32(reader["Adults"]);
                                booking.Amount = Convert.ToDecimal(reader["Amount"]);
                                //booking.Balance = Convert.ToDecimal(reader["Balance"]);
                                booking.BookingDate = reader["BookingDate"].ToString();
                                //booking.BookingID = Convert.ToInt32(reader["BookingID"]);
                                //booking.BookingsDetailsID = Convert.ToInt32(reader["BookingsDetailsID"]);
                                //booking.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                                //booking.CategoryName = reader["CategoryName"].ToString();
                                booking.CheckInDate = reader["CheckIn"].ToString();
                                booking.CheckOutDate = reader["CheckOut"].ToString();
                                booking.Children = Convert.ToInt32(reader["Children"]);
                                booking.Email = reader["Email"].ToString();
                                //booking.FloorsID = Convert.ToInt32(reader["FloorsID"]);
                                booking.FullName = reader["FullName"].ToString();
                                //booking.Gender = reader["Gender"].ToString();
                                //booking.IdentityType = reader["IdentityType"].ToString();
                                booking.LoginName = reader["LoginName"].ToString();
                                booking.Nights = Convert.ToInt32(reader["Nights"]);
                                //booking.NightText = reader["NightText"].ToString();
                                booking.NoOfRooms = Convert.ToInt32(reader["NoOfRooms"]);
                                booking.PaymentMethod = reader["PaymentMethod"].ToString();
                                booking.Phone = reader["Phone"].ToString();
                                booking.RefNo = reader["RefNo"].ToString();
                                //booking.RoomID = Convert.ToInt32(reader["RoomID"]);
                                booking.RoomName = reader["RoomName"].ToString();
                                //booking.RoomStatusID = Convert.ToInt32(reader["RoomStatusID"]);
                                booking.Title = reader["Title"].ToString();
                               // booking.Total = Convert.ToDecimal(reader["Total"]);
                                //booking.UserAccessID = Convert.ToInt32(reader["UserAccessID"]);
                                booking.UserFirstName = reader["UsersFullName"].ToString();
                                //booking.UserLastName = reader["UserLastName"].ToString();
                                lst.Add(booking);
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

        public List<Bookings> BookingsLoadBySalesPerson(string fullName) {
            
            try {
                using (SqlConnection con=new SqlConnection())  {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd=new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "BookingLoadAllByFullName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        //cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        //cmd.Parameters.AddWithValue("@ToDate", toDate);

                        using (SqlDataReader reader=cmd.ExecuteReader()) {
                            List<Bookings> lst = new List<Bookings>();
                            while (reader.Read()) {
                                booking = new Bookings();

                                booking.Adults = Convert.ToInt32(reader["Adults"]);
                                booking.Amount = Convert.ToDecimal(reader["Amount"]);
                                //booking.Balance = Convert.ToDecimal(reader["Balance"]);
                                booking.BookingDate = reader["BookingDate"].ToString();
                                //booking.BookingID = Convert.ToInt32(reader["BookingID"]);
                                //booking.BookingsDetailsID = Convert.ToInt32(reader["BookingsDetailsID"]);
                                //booking.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                                //booking.CategoryName = reader["CategoryName"].ToString();
                                booking.CheckInDate = reader["CheckIn"].ToString();
                                booking.CheckOutDate = reader["CheckOut"].ToString();
                                booking.Children = Convert.ToInt32(reader["Children"]);
                                booking.Email = reader["Email"].ToString();
                                //booking.FloorsID = Convert.ToInt32(reader["FloorsID"]);
                                booking.FullName = reader["FullName"].ToString();
                                //booking.Gender = reader["Gender"].ToString();
                                //booking.IdentityType = reader["IdentityType"].ToString();
                                booking.LoginName = reader["LoginName"].ToString();
                                booking.Nights = Convert.ToInt32(reader["Nights"]);
                                //booking.NightText = reader["NightText"].ToString();
                                booking.NoOfRooms = Convert.ToInt32(reader["NoOfRooms"]);
                                booking.PaymentMethod = reader["PaymentMethod"].ToString();
                                booking.Phone = reader["Phone"].ToString();
                                booking.RefNo = reader["RefNo"].ToString();
                                //booking.RoomID = Convert.ToInt32(reader["RoomID"]);
                                booking.RoomName = reader["RoomName"].ToString();
                                //booking.RoomStatusID = Convert.ToInt32(reader["RoomStatusID"]);
                                booking.Title = reader["Title"].ToString();
                               // booking.Total = Convert.ToDecimal(reader["Total"]);
                                //booking.UserAccessID = Convert.ToInt32(reader["UserAccessID"]);
                                booking.UserFirstName = reader["SalesPerson"].ToString();
                                //booking.UserLastName = reader["UserLastName"].ToString();
                                lst.Add(booking);
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
    }
}
