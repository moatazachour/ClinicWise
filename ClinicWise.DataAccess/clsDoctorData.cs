using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsDoctorData
    {
        public static async Task<int> AddNewDoctorAsync(int personID, int specializationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Doctor_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@SpecializationID", specializationID);

                SqlParameter outputParam = new SqlParameter("@DoctorID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);


                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    return (int)command.Parameters["@DoctorID"].Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
