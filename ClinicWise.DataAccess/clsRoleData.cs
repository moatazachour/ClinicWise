using ClinicWise.Contracts.Patients;
using ClinicWise.Contracts.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsRoleData
    {
        public static async Task<List<RoleDTO>> GetAllAsync()
        {
            List<RoleDTO> roles = new List<RoleDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Role_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new RoleDTO
                            (
                                (int)reader["RoleID"],
                                (string)reader["Name"]
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return roles;
        }

        public static async Task<RoleDTO> GetByIDAsync(int roleID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Role_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleID", SqlDbType.VarChar).Value = roleID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new RoleDTO(
                                roleID,
                                (string)reader["RoleName"]);
                        }

                        return null;
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static RoleDTO GetByRoleName(string roleName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Role_GetByRoleName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = roleName;

                connection.Open();

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new RoleDTO(
                                (int)reader["RoleID"],
                                roleName);
                        }

                        return null;
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }
    }
}
