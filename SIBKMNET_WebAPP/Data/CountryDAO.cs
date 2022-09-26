using SIBKMNET_WebAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebAPP.Data
{
    internal class CountryDAO
    {
        private string connectionString = "Data Source=LAPTOP-LE58BBBM;Initial Catalog=SIBKMNET;" + "User ID=sibkmnet;Password=111;Connect Timeout=30;";
        public List <Country> FetchAll()
        {
            List<Country> returnList = new List<Country>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Select * from Country";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Country country = new Country();
                        country.Id = reader.GetInt32(0);
                        country.Name = reader.GetString(1);

                        returnList.Add(country);
                    }
                }
                return returnList;
            }
        }

        public Country FetchOne(int id)
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Select * from Country WHERE Id = @id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Country country = new Country();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        country.Id = reader.GetInt32(0);
                        country.Name = reader.GetString(1);

                        
                    }
                }
                return country;
            }
            
        }
        public int CreateorUpdate(Country country)
        {
            //Kalo country.id <=1 maka create
            // kalo >=1 maka update

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if (country.Id <= 0)
                {
                    sqlQuery = " Insert into Country values(@Name)";
                }
                else
                {
                    sqlQuery = "Update Country SET name = (@Name) Where Id = (@Id)";
                }
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = country.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = country.Name;
                int newID = command.ExecuteNonQuery();
                return newID;


            }

               
        }

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Delete from Country Where @Id = id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = id;

                connection.Open();
                int deletedId = command.ExecuteNonQuery();

                return deletedId;
            }
        }
    }
}
