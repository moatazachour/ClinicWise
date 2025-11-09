using ClinicWise.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsUserData
    {
        public static int AddNew(
            int personID, 
            string username, 
            string password, 
            int roleID, 
            bool isActive,
            int createdByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("User_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                SqlParameter outputParam = new SqlParameter("@UserID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();

                    object result = command.Parameters["@UserID"].Value;
                    return result == DBNull.Value ? -1 : (int)result;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
                
            }
        }

        public static async Task<bool> IsPersonAssignedToUserAccountAsync(int personID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("User_IsPersonAssignedToUserAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

                SqlParameter outputParam = new SqlParameter("@Exists", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                await connection.OpenAsync();

                try
                {
                    await command.ExecuteNonQueryAsync();

                    return (bool)command.Parameters["@Exists"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw; 
                }
            }
        }

        public static async Task<List<UserDisplayDTO>> GetAllAsync()
        {
            List<UserDisplayDTO> users = new List<UserDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("User_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        users.Add(new UserDisplayDTO(
                            (int)reader["UserID"],
                            (string)reader["Username"],
                            (string)reader["RoleName"],
                            (string)reader["IsActiveCaption"],
                            (string)reader["CreatedBy"]
                            ));
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return users;
        }

        public static async Task<UserDTO> GetByUsernameAndPasswordAsync(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("User_GetByUsernameAndPassword", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

                await connection.OpenAsync();

                try
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        return new UserDTO(
                            (int)reader["UserID"],
                            (int)reader["PersonID"],
                            (string)reader["Username"],
                            (string)reader["Password"],
                            (int)reader["RoleID"],
                            (bool)reader["IsActive"],
                            (int)reader["CreatedByUserID"]);
                    }

                    return null;
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
