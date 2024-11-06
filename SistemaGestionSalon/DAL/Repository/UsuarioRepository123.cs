using ENTITY;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Repository
{
    public class UsuarioRepository
    {
        private readonly string connectionString = "Data Source=SQL8010.site4now.net;Initial Catalog=db_aaba45_core;Persist Security Info=True;User ID=db_aaba45_core_admin;Password=Developer05;TrustServerCertificate=True;";

        public Base Login(string user = "", string password = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[Salon].[SP_Login]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", user);
                    command.Parameters.AddWithValue("@Contrasena", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Base
                            {
                                CODE = reader[0].ToString(),
                                ACTION = reader[1].ToString(),
                                MSJ = reader[2].ToString(),
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Usuarios> ObtenerUsuario(string user = "")
        {
            var usuarios = new List<Usuarios>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[Salon].[SP_ObtenerUsuarios]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", user);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuarios
                            {
                                UsuarioID =int.Parse(reader["UsuarioID"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                Usuario = reader["Usuario"].ToString(),
                                Rol=reader["Rol"].ToString(),
                            });
                        }
                    }
                }
            }
            return usuarios;
        }

        public void CambiarClave(int? UserId = 0, string pass = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[Salon].[SP_CambiarClave]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@pass", pass);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Usuarios CrearUsuario(Usuarios u)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[Salon].[sp_InsertOrUpdateUsuario]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UsuarioID", u.UsuarioID);
                    command.Parameters.AddWithValue("@Nombre", u.Nombre);
                    command.Parameters.AddWithValue("@Usuario", u.Usuario);
                    command.Parameters.AddWithValue("@Contrasena", u.Contrasena);
                    command.Parameters.AddWithValue("@Rol", u.Rol);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuarios
                            {
                                // Asigna las propiedades de la clase `Usuarios` desde el lector
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void EliminarUsuario(int UsuarioID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[Salon].[sp_EliminarUsuario]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UsuarioID", UsuarioID);

                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
