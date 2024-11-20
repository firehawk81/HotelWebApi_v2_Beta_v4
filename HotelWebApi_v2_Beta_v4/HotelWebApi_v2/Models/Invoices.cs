using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWebApi_v2.Models
{
    public class Invoices
    {
        public int InvoicesID { get; set; }
        public int CustomersID { get; set; }
        public string AccountName { get; set; }
        public string SalesAccountName { get; set; }
        public decimal AmountPaid { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public bool Booked { get; set; }
        public bool CheckedIn { get; set; }
        public bool Paid { get; set; }
        public bool IsCheckIn { get; set; }
        public decimal Balance { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal Discount { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public string TransactDate { get; set; }
        public string RoomName { get; set; }
        public string CategoryName { get; set; }
        public int Rooms { get; set; }
        public int Nights { get; set; }
        public string Details { get; set; }
        public string PaymentMethod { get; set; }
        public string RefNo { get; set; }
        public string LoginName { get; set; }
        public string UserFullName { get; set; }
        //public string UserLastName { get; set; }


        public List<Invoices> CustomersInvoices(string refNo) {
        Invoices invoice;
        try {
            using (SqlConnection con = new SqlConnection()) {
                con.ConnectionString = Properties.Settings.Default.ConnectionStr;

                using (SqlCommand cmd = new SqlCommand()) {
                    cmd.Connection = con;
                    cmd.CommandText = "CustomersInvoices_sp";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@RefNo", refNo);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        List<Invoices> lst = new List<Invoices>();
                        while (reader.Read()) {

                            invoice = new Invoices();
                            invoice.AccountName = reader["AccountName"].ToString();
                            invoice.Phone = reader["Phone"].ToString();
                            invoice.Address = reader["Address"].ToString();
                            invoice.CheckInDate = reader["CheckIn"].ToString();
                            invoice.CheckOutDate = reader["CheckOut"].ToString();
                            invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                            invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                            invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                            invoice.Discount = Convert.ToDecimal(reader["Discount"]);
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
        catch (Exception ex) {
            ex.ToString();
            return null;
        }
      }
        public List<Invoices> CustomersInvoicesLoadAll() {
            Invoices invoice;
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                        using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomersInvoicesLoadAll_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            List<Invoices> lst = new List<Invoices>();
                            while (reader.Read()) {

                                invoice = new Invoices();
                                invoice.AccountName = reader["AccountName"].ToString();
                                invoice.Phone = reader["Phone"].ToString();
                                invoice.Address = reader["Address"].ToString();
                                //invoice.CheckInDate = reader["CheckIn"].ToString();
                                //invoice.CheckOutDate = reader["CheckOut"].ToString();
                                invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                                invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                                invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                                invoice.Discount = Convert.ToDecimal(reader["Discount"]);
                                //invoice.Rate = Convert.ToDecimal(reader["Rate"]);
                                invoice.TransactDate = reader["TransactDate"].ToString();
                                //invoice.Rooms = Convert.ToInt32(reader["NoOfRooms"]);
                                //invoice.Nights = Convert.ToInt32(reader["Nights"]);
                                invoice.Details = reader["Details"].ToString();
                                //invoice.PaymentMethod = reader["PaymentMethod"].ToString();
                                invoice.UserFullName = reader["UserFullName"].ToString();
                                invoice.RefNo = reader["RefNO"].ToString();
                                lst.Add(invoice);
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
        public List<Invoices> CustomersInvoicesLoadAll_web() {
        Invoices invoice;
        try {
            using (SqlConnection con = new SqlConnection()) {
                con.ConnectionString = "Data Source =.\\MSSQLSERVER2012;Initial Catalog=Ibomwater_db;User ID=Ibom_user;Password=@Down1234#;Integrated Security=False";
                                    // "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";
                    using (SqlCommand cmd = new SqlCommand()) {
                    cmd.Connection = con;
                    cmd.CommandText = "CustomersInvoicesLoadAll_sp";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                        
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        List<Invoices> lst = new List<Invoices>();
                        while (reader.Read()) {

                            invoice = new Invoices();
                            invoice.CustomersID = Convert.ToInt32(reader["CustomersID"]);
                            invoice.AccountName = reader["AccountName"].ToString();
                            invoice.Phone = reader["Phone"].ToString();
                            invoice.Address = reader["Address"].ToString();
                            invoice.CheckInDate = reader["CheckIn"].ToString();
                            invoice.CheckOutDate = reader["CheckOut"].ToString();
                            invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                            invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                            invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                            invoice.Discount = Convert.ToDecimal(reader["Discount"]);
                            invoice.Rate = Convert.ToDecimal(reader["Rate"]);
                            invoice.TransactDate = reader["TransactDate"].ToString();
                            invoice.Rooms = Convert.ToInt32(reader["NoOfRooms"]);
                            invoice.Nights = Convert.ToInt32(reader["Nights"]);
                            //invoice.Details = reader["Details"].ToString();
                            //invoice.PaymentMethod = reader["PaymentMethod"].ToString();
                            invoice.UserFullName = reader["UserFullName"].ToString();
                            invoice.RefNo = reader["RefNO"].ToString();
                            lst.Add(invoice);
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
        public List<Invoices> CustomersInvoicesByTransactDate_web(string transactDate) {
        Invoices invoice;
        try {
            using (SqlConnection con = new SqlConnection()) {
                con.ConnectionString = "Data Source = .\\SQLEXPRESS; Initial Catalog = Ibomwater_db; User ID = Ibom_user; Password = @Down1234#;Integrated Security=False";
                                     //"Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand()) {
                    cmd.Connection = con;
                    cmd.CommandText = "CustomersInvoicesByTransactDate_sp";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@TransactDate", transactDate);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        List<Invoices> lst = new List<Invoices>();
                        while (reader.Read()) {

                            invoice = new Invoices();
                            invoice.CustomersID = Convert.ToInt32(reader["CustomersID"]);
                            invoice.AccountName = reader["AccountName"].ToString();
                            invoice.Phone = reader["Phone"].ToString();
                            invoice.Address = reader["Address"].ToString();
                            invoice.CheckInDate = reader["CheckIn"].ToString();
                            invoice.CheckOutDate = reader["CheckOut"].ToString();
                            invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                            invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                            invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                            invoice.Discount = Convert.ToDecimal(reader["Discount"]);
                            invoice.Rate = Convert.ToDecimal(reader["Rate"]);
                            invoice.TransactDate = reader["TransactDate"].ToString();
                            invoice.Rooms = Convert.ToInt32(reader["NoOfRooms"]);
                            invoice.Nights = Convert.ToInt32(reader["Nights"]);
                            //invoice.Details = reader["Details"].ToString();
                            //invoice.PaymentMethod = reader["PaymentMethod"].ToString();
                            invoice.UserFullName = reader["UserFullName"].ToString();
                            invoice.RefNo = reader["RefNO"].ToString();
                            lst.Add(invoice);
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
        bool SalesAccountUpdatesDailySales(decimal credit, string accountName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "SalesAccountUpdatesDailySales_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@Credit", credit);
                        cmd.Parameters.AddWithValue("@SalesAccountName", accountName);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        public List<Invoices> CustomersInvoicesLoadAll(string refNo)
        {
            Invoices invoice;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomersInvoices_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@RefNo", refNo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<Invoices> lst = new List<Invoices>();
                            while (reader.Read())
                            {

                                invoice = new Invoices();
                                invoice.AccountName = reader["AccountName"].ToString();
                                invoice.Phone = reader["Phone"].ToString();
                                invoice.Address = reader["Address"].ToString();
                                invoice.CheckInDate = reader["CheckIn"].ToString();
                                invoice.CheckOutDate = reader["CheckOut"].ToString();
                                invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                                invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                                invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                                invoice.Discount = Convert.ToDecimal(reader["Discount"]);
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
        public List<Invoices> ReservationLoadAll()
        {
            Invoices invoice;
            try {
                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = "Data Source =.\\MSSQLSERVER2012;Initial Catalog=Ibomwater_db;User ID=Ibom_user;Password=@Down1234#;Integrated Security=False";

                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "ReservationLoadAll_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            List<Invoices> lst = new List<Invoices>();
                            while (reader.Read()) {

                                invoice = new Invoices();
                                invoice.AccountName = reader["AccountName"].ToString();
                                invoice.Phone = reader["Phone"].ToString();
                                invoice.Address = reader["Address"].ToString();
                                invoice.Adults = Convert.ToInt32(reader["Adults"]);
                                invoice.Children = Convert.ToInt32(reader["Children"]);
                                invoice.CheckInDate = reader["CheckIn"].ToString();
                                invoice.CheckOutDate = reader["CheckOut"].ToString();
                                invoice.Booked = Convert.ToBoolean(reader["Booked"]);
                                invoice.CheckedIn = Convert.ToBoolean(reader["CheckedIn"]);
                                invoice.Paid = Convert.ToBoolean(reader["Paid"]);
                                invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                                invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                                invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                                invoice.Discount = Convert.ToDecimal(reader["Discount"]);
                                invoice.Rate = Convert.ToDecimal(reader["Rate"]);
                                invoice.Total = Convert.ToDecimal(reader["Total"]);
                                invoice.TransactDate = reader["TransactDate"].ToString();
                                invoice.RoomName = reader["RoomName"].ToString();
                                invoice.CategoryName = reader["CategoryName"].ToString();
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
            catch (Exception ex) {
                ex.ToString();
                return null;
            }
        }
        public bool POST_PayIn(Invoices credit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "POST_PayIn_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@AccountName", credit.AccountName));
                        cmd.Parameters.Add(new SqlParameter("@SalesAccountName", credit.SalesAccountName));
                        //cmd.Parameters.Add(new SqlParameter("@AmountPaid", credit.AmountPaid));

                        cmd.Parameters.Add(new SqlParameter("@TransactDate", Convert.ToDateTime(credit.TransactDate)));
                        cmd.Parameters.Add(new SqlParameter("@Details", credit.Details));
                        cmd.Parameters.Add(new SqlParameter("@Credit", credit.Credit));
                        cmd.Parameters.Add(new SqlParameter("@Debit", credit.Debit));

                        cmd.Parameters.Add(new SqlParameter("@RefNo", credit.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@LoginName", credit.LoginName));

                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        public bool POST_PayOut(Invoices credit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "POST_PayOut_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@AccountName", credit.AccountName));
                        cmd.Parameters.Add(new SqlParameter("@SalesAccountName", credit.SalesAccountName));
                        //cmd.Parameters.Add(new SqlParameter("@AmountPaid", credit.AmountPaid));

                        cmd.Parameters.Add(new SqlParameter("@TransactDate", Convert.ToDateTime(credit.TransactDate)));
                        cmd.Parameters.Add(new SqlParameter("@Details", credit.Details));
                        cmd.Parameters.Add(new SqlParameter("@Credit", credit.Credit));
                        cmd.Parameters.Add(new SqlParameter("@Debit", credit.Debit));

                        cmd.Parameters.Add(new SqlParameter("@RefNo", credit.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@LoginName", credit.LoginName));
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        public bool POST_PayInDailySales(Invoices credit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "POST_PayInDailySales_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@AccountName", credit.AccountName));
                        //cmd.Parameters.Add(new SqlParameter("@AmountPaid", credit.AmountPaid));

                        cmd.Parameters.Add(new SqlParameter("@TransactDate", Convert.ToDateTime(credit.TransactDate)));
                        cmd.Parameters.Add(new SqlParameter("@Details", credit.Details));
                        cmd.Parameters.Add(new SqlParameter("@Credit", credit.Credit));
                        cmd.Parameters.Add(new SqlParameter("@Debit", credit.Debit));

                        cmd.Parameters.Add(new SqlParameter("@RefNo", credit.RefNo));
                        cmd.Parameters.Add(new SqlParameter("@LoginName", credit.LoginName));
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        public decimal CheckCustomersBalance(string roomNo)
        {
            Invoices balance = new Invoices();
            decimal _balance = 0m;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "CheckCustomersBalance_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@RoomName", roomNo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {

                                balance.Balance = Convert.ToDecimal(reader["Balance"]);
                                _balance = balance.Balance;
                            }
                            return _balance;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }
        }
        public Invoices CustomerBalanceLoadByRoomName(string roomName)
        {
            Invoices balance = new Invoices();
            decimal _balance = 0m;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomerBalanceLoadByRoomName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@RoomName", roomName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {

                                balance.Balance = Convert.ToDecimal(reader["Balance"]);
                                balance.AccountName = reader["AccountName"].ToString();
                                balance.Phone = reader["Phone"].ToString();
                                _balance = balance.Balance;
                            }
                            return balance;
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
        public Invoices CustomerAndRoomInfoByCustomerName(string fullName)
        {
            Invoices invoice = new Invoices();
            decimal _balance = 0m;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomerAndRoomInfoByCustomerName_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@AccountName", fullName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {

                                invoice.AccountName = reader["AccountName"].ToString();
                                invoice.Phone = reader["Phone"].ToString();
                                invoice.Address = reader["Address"].ToString();
                                invoice.Adults = Convert.ToInt32(reader["Adults"]);
                                invoice.Children = Convert.ToInt32(reader["Children"]);
                                invoice.CheckInDate = reader["CheckIn"].ToString();
                                invoice.CheckOutDate = reader["CheckOut"].ToString();
                                invoice.Booked = Convert.ToBoolean(reader["Booked"]);
                                invoice.CheckedIn = Convert.ToBoolean(reader["CheckedIn"]);
                                invoice.Paid = Convert.ToBoolean(reader["Paid"]);
                                invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                                invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                                invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                                invoice.Discount = Convert.ToDecimal(reader["Discount"]);
                                invoice.Rate = Convert.ToDecimal(reader["Rate"]);
                                invoice.Total = Convert.ToDecimal(reader["Total"]);
                                invoice.TransactDate = reader["TransactDate"].ToString();
                                invoice.RoomName = reader["RoomName"].ToString();
                                invoice.CategoryName = reader["CategoryName"].ToString();
                                invoice.Rooms = Convert.ToInt32(reader["NoOfRooms"]);
                                invoice.Nights = Convert.ToInt32(reader["Nights"]);
                                invoice.Details = reader["Details"].ToString();
                                invoice.PaymentMethod = reader["PaymentMethod"].ToString();
                                invoice.UserFullName = reader["UserFullName"].ToString();
                                invoice.RefNo = reader["RefNO"].ToString();
                            }
                            return invoice;
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
        public List<Invoices> CustomerBookingsByFullNmaeForCheckInOut(string fullName)
        {
            Invoices invoice;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomerBookingsByFullNmaeForCheckInOut_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@AccountName", fullName);
                        List<Invoices> lst = new List<Invoices>();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {

                                invoice = new Invoices();
                                invoice.AccountName = reader["AccountName"].ToString();
                                invoice.Phone = reader["Phone"].ToString();
                                invoice.Address = reader["Address"].ToString();
                                invoice.Adults = Convert.ToInt32(reader["Adults"]);
                                invoice.Children = Convert.ToInt32(reader["Children"]);
                                invoice.CheckInDate = reader["CheckIn"].ToString();
                                invoice.CheckOutDate = reader["CheckOut"].ToString();
                                invoice.Booked = Convert.ToBoolean(reader["Booked"]);
                                invoice.CheckedIn = Convert.ToBoolean(reader["CheckedIn"]);
                                invoice.Paid = Convert.ToBoolean(reader["Paid"]);
                                invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                                invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                                invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                                invoice.Discount = Convert.ToDecimal(reader["Discount"]);
                                invoice.Rate = Convert.ToDecimal(reader["Rate"]);
                                invoice.Total = Convert.ToDecimal(reader["Total"]);
                                invoice.TransactDate = reader["TransactDate"].ToString();
                                invoice.RoomName = reader["RoomName"].ToString();
                                invoice.CategoryName = reader["CategoryName"].ToString();
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
        public Invoices CustomerBookingsByRoomNameForCheckInOut(string roomName)
        {
            Invoices invoice = new Invoices();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "CustomerBookingsByRoomNameForCheckInOut_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.AddWithValue("@RoomName", roomName);
                        List<Invoices> lst = new List<Invoices>();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {

                                invoice.AccountName = reader["AccountName"].ToString();
                                invoice.Phone = reader["Phone"].ToString();
                                invoice.Address = reader["Address"].ToString();
                                invoice.Adults = Convert.ToInt32(reader["Adults"]);
                                invoice.Children = Convert.ToInt32(reader["Children"]);
                                invoice.CheckInDate = reader["CheckIn"].ToString();
                                invoice.CheckOutDate = reader["CheckOut"].ToString();
                                invoice.Booked = Convert.ToBoolean(reader["Booked"]);
                                invoice.CheckedIn = Convert.ToBoolean(reader["CheckedIn"]);
                                invoice.Paid = Convert.ToBoolean(reader["Paid"]);
                                invoice.Balance = Convert.ToDecimal(reader["Balance"]);
                                invoice.Credit = Convert.ToDecimal(reader["Credit"]);
                                invoice.Debit = Convert.ToDecimal(reader["Debit"]);
                                invoice.Discount = Convert.ToDecimal(reader["Discount"]);
                                invoice.Rate = Convert.ToDecimal(reader["Rate"]);
                                invoice.Total = Convert.ToDecimal(reader["Total"]);
                                invoice.TransactDate = reader["TransactDate"].ToString();
                                invoice.RoomName = reader["RoomName"].ToString();
                                invoice.CategoryName = reader["CategoryName"].ToString();
                                invoice.Rooms = Convert.ToInt32(reader["NoOfRooms"]);
                                invoice.Nights = Convert.ToInt32(reader["Nights"]);
                                invoice.Details = reader["Details"].ToString();
                                invoice.PaymentMethod = reader["PaymentMethod"].ToString();
                                invoice.UserFullName = reader["UserFullName"].ToString();
                                invoice.RefNo = reader["RefNO"].ToString();
                            }
                            return invoice;
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
        public bool PostOutStanding(string rooMname, decimal balance)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=appsoft;Integrated Security=True";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "PostOutStanding_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@RoomName", rooMname));
                        cmd.Parameters.Add(new SqlParameter("@Balance", balance));
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
    }
}