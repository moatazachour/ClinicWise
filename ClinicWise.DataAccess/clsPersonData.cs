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

                command.Parameters.AddWithValue("@NationalNo", nationalNo);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Email", email);
                if (string.IsNullOrWhiteSpace(address))
                    command.Parameters.AddWithValue("@Address", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Address", address);

                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

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
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                    throw;
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

                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@NationalNo", nationalNo);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Phone", phone);

                if (string.IsNullOrWhiteSpace(email))
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Email", email);

                if (string.IsNullOrWhiteSpace(address))
                    command.Parameters.AddWithValue("@Address", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Address", address);

                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

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
                    Console.WriteLine(ex);
                    throw;
                }
            }

            return rowsAffected > 0;
        }
    }
}
