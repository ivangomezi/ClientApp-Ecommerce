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
    public class BuysRepository
    {
        private readonly string connectionString;

        public BuysRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Insertar compra
        /// </summary>
        /// <param name="buys"></param>
        /// <returns></returns>
        public async Task<Buys> Post(Buys buys)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 11));

                    cmd.Parameters.Add(new SqlParameter("@Id_User", buys.Id_User));
                    cmd.Parameters.Add(new SqlParameter("@Id_Product", buys.Id_Product));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", buys.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@Total_Buy", buys.Total_Buy));
                    cmd.Parameters.Add(new SqlParameter("@Code_Buy", buys.Code_Buy));

                    #region parametros adicionales
                    cmd.Parameters.Add(new SqlParameter("@Id_Rol", 1));
                    cmd.Parameters.Add(new SqlParameter("@User_Name", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Password", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Name_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Desc_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Price_Product", 1));
                    cmd.Parameters.Add(new SqlParameter("@Img_Product", "null"));
                    #endregion

                    Buys response = null;
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
        private Buys MapToValueInsert(SqlDataReader reader)
        {
            return new Buys()
            {
                Id_Buy = (int)reader["Id_Buy"],
                Id_User = (int)reader["Id_User"],
                Id_Product = (int)reader["Id_Product"],
                Quantity = (int)reader["Quantity"],
                Total_Buy = (int)reader["Total_Buy"]
            };
        }
    }
}
