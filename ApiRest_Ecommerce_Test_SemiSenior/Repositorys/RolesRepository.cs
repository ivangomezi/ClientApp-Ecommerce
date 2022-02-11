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
    public class RolesRepository
    {
        private readonly string connectionString;

        public RolesRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Lista roles
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<List<Roles>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 5));

                    cmd.Parameters.Add(new SqlParameter("@Id_User", 1));
                    cmd.Parameters.Add(new SqlParameter("@User_Name", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Password", "null"));

                    #region parametros adicional
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

                    List<Roles> lista = new List<Roles>();
                    Roles response = null;
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
        private Roles MapToValueAll(SqlDataReader reader)
        {
            return new Roles()
            {
                Id_Rol = (int)reader["Id_Rol"],
                Rol_Name = reader["Rol_Name"].ToString()
            };
        }
    }
}
