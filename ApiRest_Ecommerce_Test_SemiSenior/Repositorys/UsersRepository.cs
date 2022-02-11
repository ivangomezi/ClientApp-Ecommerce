using ApiRest_Ecommerce_Test_SemiSenior.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Ecommerce_Test_SemiSenior.Repositorys
{
    public class UsersRepository
    {
        private readonly string connectionString;

        public UsersRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Login plataforma
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<Users> Get(string user, string pass)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 1));

                    cmd.Parameters.Add(new SqlParameter("@User_Name", user));
                    cmd.Parameters.Add(new SqlParameter("@Password", pass));

                    #region parametros adicional
                    cmd.Parameters.Add(new SqlParameter("@Id_User", 1));
                    cmd.Parameters.Add(new SqlParameter("@Id_Rol", 1));
                    cmd.Parameters.Add(new SqlParameter("@Id_Product", 1));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Name_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Desc_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Price_Product", 1));
                    cmd.Parameters.Add(new SqlParameter("@Img_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", 1));
                    cmd.Parameters.Add(new SqlParameter("@Total_Buy", 1));
                    cmd.Parameters.Add(new SqlParameter("@Code_Buy", "null"));
                    #endregion

                    Users response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }
                    }

                    return response;
                }
            }
        }
        /// <summary>
        /// Map Resultados Consulta
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Users MapToValue(SqlDataReader reader)
        {
            return new Users()
            {
                Id_User = (int)reader["Id_User"],
                Id_Rol = (int)reader["Id_Rol"]

                //exampleEcommerce = reader["exampleEcommerce"].ToString()
            };
        }

        /// <summary>
        /// Lista usuarios
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<List<Users>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 2));

                    cmd.Parameters.Add(new SqlParameter("@Id_User", 1));
                    cmd.Parameters.Add(new SqlParameter("@User_Name", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Password", "null"));

                    cmd.Parameters.Add(new SqlParameter("@Id_Rol", 1));
                    cmd.Parameters.Add(new SqlParameter("@Id_Product", 1));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Name_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Desc_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Price_Product", 1));
                    cmd.Parameters.Add(new SqlParameter("@Img_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", 1));
                    cmd.Parameters.Add(new SqlParameter("@Total_Buy", 1));
                    cmd.Parameters.Add(new SqlParameter("@Code_Buy", "null"));

                    List<Users> lista = new List<Users>();
                    Users response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValueAll(reader);
                            lista.Add(response);
                        }
                    }

                    return lista;
                }
            }
        }
        /// <summary>
        /// Map Resultados Consulta
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Users MapToValueAll(SqlDataReader reader)
        {
            return new Users()
            {
                Id_User = (int)reader["Id_User"],
                User_Name = reader["User_Name"].ToString(),
                Rol = reader["Rol_Name"].ToString()
            };
        }

        /// <summary>
        /// Insertar user
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<Users> Post(Users users)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 3));

                    cmd.Parameters.Add(new SqlParameter("@Id_User", 1));
                    cmd.Parameters.Add(new SqlParameter("@User_Name", users.User_Name));
                    cmd.Parameters.Add(new SqlParameter("@Password", users.Password));
                    cmd.Parameters.Add(new SqlParameter("@Id_Rol", users.Id_Rol));

                    #region parametros adicionales
                    cmd.Parameters.Add(new SqlParameter("@Id_Product", 1));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Name_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Desc_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Price_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Img_Product", "null"));

                    cmd.Parameters.Add(new SqlParameter("@Quantity", 1));
                    cmd.Parameters.Add(new SqlParameter("@Total_Buy", 1));
                    cmd.Parameters.Add(new SqlParameter("@Code_Buy", "null"));
                    #endregion

                    Users response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValueInsert(reader);
                        }
                    }

                    return response;
                }
            }
        }
        /// <summary>
        /// Map Resultados Consulta
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Users MapToValueInsert(SqlDataReader reader)
        {
            return new Users()
            {
                Id_User = (int)reader["Id_User"],
                Id_Rol = (int)reader["Id_Rol"],
                User_Name = reader["User_Name"].ToString(),
                Password = reader["Password"].ToString()
            };
        }
    }
}
