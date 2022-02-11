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
    public class ProductsRepository
    {
        private readonly string connectionString;

        public ProductsRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Detalles productos id
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<Products> GetId(int products)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 7));

                    cmd.Parameters.Add(new SqlParameter("@Id_User", 1));
                    cmd.Parameters.Add(new SqlParameter("@User_Name", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Password", "null"));

                    #region parametros adicionales
                    cmd.Parameters.Add(new SqlParameter("@Id_Rol", 1));
                    cmd.Parameters.Add(new SqlParameter("@Id_Product", products));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Name_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Desc_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Price_Product", 1));
                    cmd.Parameters.Add(new SqlParameter("@Img_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", 1));
                    cmd.Parameters.Add(new SqlParameter("@Total_Buy", 1));
                    cmd.Parameters.Add(new SqlParameter("@Code_Buy", "null"));
                    #endregion

                    Products response = null;
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
        private Products MapToValue(SqlDataReader reader)
        {
            return new Products()
            {
                Id_Product = (int)reader["Id_Product"],
                Cod_Product = reader["Cod_Product"].ToString(),
                Name_Product = reader["Name_Product"].ToString(),
                Desc_Product = reader["Desc_Product"].ToString(),
                Price_Product = (int)reader["Price_Product"],
                Img_Product = reader["Img_Product"].ToString()
            };
        }

        /// <summary>
        /// Lista productos
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<List<Products>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 6));

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

                    List<Products> lista = new List<Products>();
                    Products response = null;
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
        private Products MapToValueAll(SqlDataReader reader)
        {
            return new Products()
            {
                Id_Product = (int)reader["Id_Product"],
                Cod_Product = reader["Cod_Product"].ToString(),
                Name_Product = reader["Name_Product"].ToString(),
                Desc_Product = reader["Desc_Product"].ToString(),
                Price_Product = (int)reader["Price_Product"],
                Img_Product = reader["Img_Product"].ToString()
            };
        }

        /// <summary>
        /// Insertar producto
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<Products> Post(Products products)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 4));

                    cmd.Parameters.Add(new SqlParameter("@Id_User", 1));
                    cmd.Parameters.Add(new SqlParameter("@User_Name", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Password", "null"));

                    cmd.Parameters.Add(new SqlParameter("@Id_Rol", 1));

                    cmd.Parameters.Add(new SqlParameter("@Id_Product", 1));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Product", products.Cod_Product));
                    cmd.Parameters.Add(new SqlParameter("@Name_Product", products.Name_Product));
                    cmd.Parameters.Add(new SqlParameter("@Desc_Product", products.Desc_Product));
                    cmd.Parameters.Add(new SqlParameter("@Price_Product", products.Price_Product));
                    cmd.Parameters.Add(new SqlParameter("@Img_Product", products.Img_Product));

                    cmd.Parameters.Add(new SqlParameter("@Quantity", 1));
                    cmd.Parameters.Add(new SqlParameter("@Total_Buy", 1));
                    cmd.Parameters.Add(new SqlParameter("@Code_Buy", "null"));

                    Products response = null;
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
        private Products MapToValueInsert(SqlDataReader reader)
        {
            return new Products()
            {
                Id_Product = (int)reader["Id_Product"],
                Cod_Product = reader["Cod_Product"].ToString(),
                Name_Product = reader["Name_Product"].ToString(),
                Desc_Product = reader["Desc_Product"].ToString(),
                Price_Product = (int)reader["Price_Product"],
                Img_Product = reader["Img_Product"].ToString()
            };
        }

        /// <summary>
        /// Insertar producto
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<Products> Put(Products products)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 8));

                    cmd.Parameters.Add(new SqlParameter("@Id_User", 1));
                    cmd.Parameters.Add(new SqlParameter("@User_Name", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Password", "null"));

                    cmd.Parameters.Add(new SqlParameter("@Id_Rol", 1));

                    cmd.Parameters.Add(new SqlParameter("@Id_Product", products.Id_Product));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Product", products.Cod_Product));
                    cmd.Parameters.Add(new SqlParameter("@Name_Product", products.Name_Product));
                    cmd.Parameters.Add(new SqlParameter("@Desc_Product", products.Desc_Product));
                    cmd.Parameters.Add(new SqlParameter("@Price_Product", products.Price_Product));
                    cmd.Parameters.Add(new SqlParameter("@Img_Product", products.Img_Product));

                    cmd.Parameters.Add(new SqlParameter("@Quantity", 1));
                    cmd.Parameters.Add(new SqlParameter("@Total_Buy", 1));
                    cmd.Parameters.Add(new SqlParameter("@Code_Buy", "null"));

                    Products response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValueUpdate(reader);
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
        private Products MapToValueUpdate(SqlDataReader reader)
        {
            return new Products()
            {
                Id_Product = (int)reader["Id_Product"],
                Cod_Product = reader["Cod_Product"].ToString(),
                Name_Product = reader["Name_Product"].ToString(),
                Desc_Product = reader["Desc_Product"].ToString(),
                Price_Product = (int)reader["Price_Product"],
                Img_Product = reader["Img_Product"].ToString()
            };
        }

        /// <summary>
        /// Eliminar producto
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<Products> Delete(int products)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_Ecommerce", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", 9));

                    cmd.Parameters.Add(new SqlParameter("@Id_User", 1));
                    cmd.Parameters.Add(new SqlParameter("@User_Name", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Password", "null"));

                    cmd.Parameters.Add(new SqlParameter("@Id_Rol", 1));

                    cmd.Parameters.Add(new SqlParameter("@Id_Product", products));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Name_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Desc_Product", "null"));
                    cmd.Parameters.Add(new SqlParameter("@Price_Product", 1));
                    cmd.Parameters.Add(new SqlParameter("@Img_Product", "null"));

                    cmd.Parameters.Add(new SqlParameter("@Quantity", 1));
                    cmd.Parameters.Add(new SqlParameter("@Total_Buy", 1));
                    cmd.Parameters.Add(new SqlParameter("@Code_Buy", "null"));

                    Products response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValueDelete(reader);
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
        private Products MapToValueDelete(SqlDataReader reader)
        {
            return new Products()
            {
                Id_Product = (int)reader["Id_Product"],
                Cod_Product = reader["Cod_Product"].ToString(),
                Name_Product = reader["Name_Product"].ToString(),
                Desc_Product = reader["Desc_Product"].ToString(),
                Price_Product = (int)reader["Price_Product"],
                Img_Product = reader["Img_Product"].ToString()
            };
        }
    }
}
