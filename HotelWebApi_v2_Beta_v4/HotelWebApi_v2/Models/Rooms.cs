using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HotelWebApi_v2.Models
{
    public class Rooms
    {
        public bool Booked { get; set; }
        public int BookingID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public decimal Rate { get; set; }
        public Byte[] RoomImage { get; set; }
        public bool CheckedIn { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string BookingDate { get; set; }
        public int Floors { get; set; }
        public int FloorsID { get; set; }
        public bool Paid { get; set; }
        public string RefNo { get; set; }
        public int RoomCount { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomNumber { get; set; }
        public int RoomStatusID { get; set; }
        public int TotalAvailable { get; set; }
        public decimal Balance { get; set; }

        // Attributes
        public string StatusColor { get; set; }
        public string DangerText { get; set; }
        public string DangerBorder { get; set; }

        // Customers Details
        public string AccountName { get; set; }

        public List<Rooms> RoomsLoadAll() {
            Rooms room;
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = "Data Source =.\\MSSQLSERVER2012;Initial Catalog=Ibomwater_db;User ID=Ibom_user;Password=@Down1234#;Integrated Security=False";
                    //Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "RoomsLoadAll_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            List<Rooms> lst = new List<Rooms>();
                            while (reader.Read()) {

                                room = new Rooms();
                                room.AccountName = reader["AccountName"].ToString();
                                room.Balance = Convert.ToDecimal(reader["Balance"]);

                                room.CheckIn = reader["CheckIn"].ToString();
                                room.CheckOut = reader["CheckOut"].ToString();
                                room.CheckedIn = (bool)reader["CheckedIn"];
                                room.Booked = (bool)reader["Booked"];

                                room.RoomName = reader["RoomName"].ToString();
                                room.RoomNumber = reader["RoomNumber"].ToString();
                                room.CategoryName = reader["CategoryName"].ToString();
                                room.RefNo = reader["RefNo"].ToString();
                                room.Balance = Convert.ToDecimal(reader["Balance"]);

                                room.DangerText = "cart_total_price ml-auto none";
                                lst.Add(room);
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
        public List<Rooms> RoomsLoadAllCategoryName(string categoryName) {
            Rooms room;
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = "Data Source =.\\MSSQLSERVER2012;Initial Catalog=Ibomwater_db;User ID=Ibom_user;Password=@Down1234#;Integrated Security=False";
                    //Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "RoomsLoadAvaibleByCategoryName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            List<Rooms> lst = new List<Rooms>();
                            while (reader.Read()) {

                                room = new Rooms();
                                room.AccountName = reader["AccountName"].ToString();
                                room.Balance = Convert.ToDecimal(reader["Balance"]);

                                room.CheckIn = reader["CheckIn"].ToString();
                                room.CheckOut = reader["CheckOut"].ToString();
                                room.CheckedIn = (bool)reader["CheckedIn"];
                                room.Booked = (bool)reader["Booked"];

                                room.RoomName = reader["RoomName"].ToString();
                                //room.RoomNumber = reader["RoomNumber"].ToString();
                                room.CategoryName = reader["CategoryName"].ToString();
                                room.RefNo = reader["RefNo"].ToString();
                                room.Booked = Convert.ToBoolean(reader["Booked"]);
                                room.CheckedIn = Convert.ToBoolean(reader["CheckedIn"]);
                                room.Paid = Convert.ToBoolean(reader["Paid"]);
                                room.Rate = Convert.ToDecimal(reader["Rate"]);
                                if (room.CheckedIn == true || room.Booked == true) {

                                    if (room.Balance > 0) {

                                        room.DangerText = "text-danger";
                                    }
                                    if (room.Booked == true && room.CheckedIn == false) {

                                        room.DangerBorder = "cart_total_price ml-auto bg-white text-primary primary-border";
                                    }
                                    if (room.CheckedIn) {

                                        room.DangerBorder = "cart_total_price ml-auto bg-white text-danger danger-border";
                                    }

                                    lst.Add(room);
                                    room.TotalAvailable = lst.Count;
                                }
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
        public Rooms RoomDetailsByCategoryName(string categoryName) {
            Rooms room = new Rooms();
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = "Data Source =.\\MSSQLSERVER2012;Initial Catalog=Ibomwater_db;User ID=Ibom_user;Password=@Down1234#;Integrated Security=False";
                    //
                    //Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "RoomsLoadAvaibleByCategoryName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            reader.Read();
                            if (reader.HasRows) {
                                
                                room.AccountName = reader["AccountName"].ToString();
                                room.Balance = Convert.ToDecimal(reader["Balance"]);

                                room.CheckIn = reader["CheckIn"].ToString();
                                room.CheckOut = reader["CheckOut"].ToString();
                                room.CheckedIn = (bool)reader["CheckedIn"];
                                room.Booked = (bool)reader["Booked"];

                                room.RoomName = reader["RoomName"].ToString();
                                //room.RoomNumber = reader["RoomNumber"].ToString();
                                room.CategoryName = reader["CategoryName"].ToString();
                                room.RefNo = reader["RefNo"].ToString();
                                room.Booked = Convert.ToBoolean(reader["Booked"]);
                                room.CheckedIn = Convert.ToBoolean(reader["CheckedIn"]);
                                room.Paid = Convert.ToBoolean(reader["Paid"]);
                                room.Rate = Convert.ToDecimal(reader["Rate"]);
                            }
                            return room;
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