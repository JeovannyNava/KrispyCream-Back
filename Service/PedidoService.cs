using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Sln2_Back.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sln2_Back.Service
{
    public class PedidoService
    {
        private readonly IConfiguration _configuration;

        public PedidoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
      
        public bool CrearPedido(Pedido pedido)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    con.Open();
                    string cadena = "insert into pedidos(Nombre,Direccion, Cantidad, DonaId) values('" + pedido.Nombre + "','" + pedido.Direccion  + "','" + pedido.Cantidad + "','" + pedido.IdDona + "')";
                    SqlCommand comando = new SqlCommand(cadena, con);
                    comando.ExecuteNonQuery();
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
            return true;
        }
        public List<Pedido> GetPedidos()
        {
            var pedidos = new List<Pedido>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    con.Close();
                    con.Open();
                    SqlCommand command = new SqlCommand("Select * from Pedidos", con);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pedidos.Add(new Pedido
                            {
                                Id = Int32.Parse(reader["Id"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                IdDona = Int32.Parse(reader["DonaId"].ToString()),
                                Cantidad = Int32.Parse(reader["Cantidad"].ToString())

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
            return pedidos;
        }
        public List<Pedido> GetPedidosKrispyCream()
        {
            var pedidos = new List<Pedido>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    con.Close();
                    con.Open();
                    SqlCommand command = new SqlCommand("Select * from Pedidos where ", con);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pedidos.Add(new Pedido
                            {
                                Id = Int32.Parse(reader["Id"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                IdDona = Int32.Parse(reader["DonaId"].ToString()),
                                Cantidad = Int32.Parse(reader["Cantidad"].ToString())
                            });
                        }
                    }
                }

                catch (Exception ex)
                {
                    _ = ex.ToString();
                  
                }
                finally
                {
                    con.Close();
                }

            }
            return pedidos;
        }
    }
}
