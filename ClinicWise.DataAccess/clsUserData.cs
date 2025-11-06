using System;
using System.Data;
using System.Data.SqlClient;

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
    }
}
