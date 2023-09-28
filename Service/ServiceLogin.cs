using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sln2_Back.Service
{
    public class ServiceLogin
    {
        private readonly IConfiguration _configuration;

        public ServiceLogin(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool IsValidUser(string username, string password)
        {


            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();

                SqlCommand command = new SqlCommand("Select * from usuarios where Nombre=@usuario and Clave=@clave", con);
                command.Parameters.AddWithValue("@usuario", username);
                command.Parameters.AddWithValue("@clave", password);
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    return reader.Read();

                }
            }
         
        }

        public string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            // Puedes agregar más claims según tus necesidades
        };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
