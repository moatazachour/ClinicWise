using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsPersonData
    {
        public static int AddNewPerson(
            string nationalNo,
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            byte gender, 
            string phone, 
            string email, 
            string address, 
            int createdByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Person_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NationalNo", SqlDbType.VarChar).Value = nationalNo;
                command.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = firstName;
                command.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = lastName;
                command.Parameters.AddWithValue("@DateOfBirth", SqlDbType.DateTime).Value = dateOfBirth;
                command.Parameters.AddWithValue("@Gender", SqlDbType.TinyInt).Value = gender;
                command.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = phone ?? (object)DBNull.Value;
                command.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = email ?? (object)DBNull.Value;
                command.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(address) ? (object)DBNull.Value : address;
                command.Parameters.AddWithValue("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                SqlParameter outputParam = new SqlParameter("@PersonID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    return (int)command.Parameters["@PersonID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw new ApplicationException("Failed to add new person.", ex);
                }
            }
        }

        public static bool Update(
            int personID, 
            string nationalNo, 
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            byte gender, 
            string phone, 
            string email, 
            string address, 
            int createdByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Person_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.AddWithValue("@NationalNo", SqlDbType.VarChar).Value = nationalNo;
                command.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = firstName;
                command.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = lastName;
                command.Parameters.AddWithValue("@DateOfBirth", SqlDbType.DateTime).Value = dateOfBirth;
                command.Parameters.AddWithValue("@Gender", SqlDbType.TinyInt).Value = gender;
                command.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = phone ?? (object)DBNull.Value;
                command.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = email ?? (object)DBNull.Value;
                command.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(address) ? (object)DBNull.Value : address;
                command.Parameters.AddWithValue("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                SqlParameter returnedParam = new SqlParameter("@ReturnVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                command.Parameters.Add(returnedParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    
                    rowsAffected = (int)returnedParam.Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw new ApplicationException("Failed to update new person.", ex);
                }
            }

            return rowsAffected > 0;
        }
    }
}
