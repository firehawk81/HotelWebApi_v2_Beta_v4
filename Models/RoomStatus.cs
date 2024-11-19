using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWebApi_v2.Models
{
    public class RoomStatus
    {
        private int _indexID;
        public int IndexID {
            set { _indexID = value; }
            get { return _indexID; }
        }

        private int _roomID;
        public int RoomID {
            set { _roomID = value; }
            get { return _roomID; }
        }

        private string _roomName;
        public string RoomName {
            set { _roomName = value; }
            get { return _roomName; }
        }

        private string _roomNo;
        public string RoomNo {
            set { _roomNo = value; }
            get { return _roomNo; }
        }

        private bool _booked;
        public bool Booked {
            set { _booked = value; }
            get { return _booked; }
        }

        private bool _paid;
        public bool Paid {
            set { _paid = value; }
            get { return _paid; }
        }

        private bool _checkedIn;
        public bool CheckedIn {
            set { _checkedIn = value; }
            get { return _checkedIn; }
        }

        private bool isCheckIn;
        public bool IsCheckIn {
            set { isCheckIn = value; }
            get { return isCheckIn; }
        }

        private DateTime _checkIn;
        public DateTime CheckIn {
            set { _checkIn = value; }
            get { return _checkIn; }
        }

        private DateTime _checkOut;
        public DateTime CheckOut {
            set { _checkOut = value; }
            get { return _checkOut; }
        }

        public bool CheckInOutGuests(Invoices guestCheckInOut) { //bool isChekIn, 
            
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = "Data Source =.\\MSSQLSERVER2012;Initial Catalog=Ibomwater_db;User ID=Ibom_user;Password=@Down1234#;Integrated Security=False";
                    //Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "CheckInOutGuests_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@IsChekIn", guestCheckInOut.IsCheckIn));
                        cmd.Parameters.Add(new SqlParameter("@CheckIn", guestCheckInOut.CheckInDate));
                        cmd.Parameters.Add(new SqlParameter("@CheckOut", guestCheckInOut.CheckOutDate));
                        cmd.Parameters.Add(new SqlParameter("@RefNo", guestCheckInOut.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@RoomName", guestCheckInOut.RoomName));
                        cmd.Parameters.Add(new SqlParameter("@Phone", guestCheckInOut.Phone));
                        cmd.Parameters.Add(new SqlParameter("@AccountName", guestCheckInOut.AccountName));
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
