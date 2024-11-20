using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesCreator.Models
{
    public class Sides
    {
        public int SidesID { get; set; }
        public string ItemName { get; set; }
        public int ItemID { get; set; }

        public bool SidesInsert(Sides sides)
        {
            try {

                using (SqlConnection con = new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "SidesInsert_sp";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@ItemName", sides.ItemName));
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

        public List<Sides> SidesLoadAll() {
            Sides sides;
            try {
                using (SqlConnection con =new SqlConnection()) {
                    con.ConnectionString = HotelWebApi_v2.Properties.Settings.Default.ConnectionStr;

                    using (SqlCommand cmd=new SqlCommand()) {
                        cmd.Connection = con;
                        cmd.CommandText = "SidesLoadAll";
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader reader=cmd.ExecuteReader()) {
                            List<Sides> lst = new List<Sides>();
                            
                            while (reader.Read()) {

                                sides = new Sides();
                                sides.ItemName = reader["ItemName"].ToString();
                                lst.Add(sides);
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