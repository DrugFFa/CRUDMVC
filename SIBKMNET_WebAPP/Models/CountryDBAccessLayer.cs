using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SIBKMNET_WebAPP.Models;

namespace SIBKMNET_WebAPP.Models
{
    public class CountryDBAccessLayer
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-LE58BBBM;Initial Catalog=SIBKMNET; User ID=sibkmnet;Password=111;Connect Timeout=30;");


        public string AddCountry(Country country)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("InsertCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Name", country.Name);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }

       
    }
}
