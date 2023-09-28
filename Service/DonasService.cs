using Microsoft.Extensions.Configuration;
using Sln2_Back.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sln2_Back.Service
{
    public class DonasService
    {
        private readonly IConfiguration _configuration;

        public DonasService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Dona> GetDonas()
        {
            var donas = new List<Dona>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    con.Close();
                    con.Open();
                    SqlCommand command = new SqlCommand("Select * from Donas", con);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            donas.Add(new Dona
                            {
                                Id = Int32.Parse(reader["Id"].ToString()),
                                Nombre = reader["Nombre"].ToString()
                            });
                        }
                    }
                }

                catch (Exception ex)
                {
                    _ = ex.ToString();
                    throw;
                }
                finally
                {
                    con.Close();
                }

            }
            return donas;
        }
    }
}
