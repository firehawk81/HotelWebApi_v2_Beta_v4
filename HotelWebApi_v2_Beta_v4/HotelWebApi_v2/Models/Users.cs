using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesCreator.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Users> UsersLoadAll() {
            Users user;
            try {
                using (SqlConnection con =new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd=new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "UsersLoadAll_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader reader=cmd.ExecuteReader()) {
                            List<Users> lst = new List<Users>();
                            while (reader.Read()) {

                                user = new Users();
                                user.UserID = Convert.ToInt32(reader["ID"]);
                                user.LoginName = reader["LoginName"].ToString();
                                user.FirstName = reader["FullName"].ToString();
                                user.LastName = reader["LastName"].ToString();
                                user.FullName = user.FirstName + " " + user.LastName;
                                user.Phone = reader["Phone"].ToString();
                                user.Email = reader["Email"].ToString();
                                lst.Add(user);
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
