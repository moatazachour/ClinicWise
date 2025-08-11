using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsDoctorData
    {
        public static int AddNewDoctor(int personID, int specializationID)
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
                    connection.Open();
                    command.ExecuteNonQuery();

                    return (int)command.Parameters["@DoctorID"].Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                    throw;
                }
            }
        }

        public static async Task<DataTable> GetAllDoctors()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Doctor_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                    throw;
                }
            }

            return dt;
        }

        public static async Task<(bool isFound, 
            string nationalNo, 
            int specializationID, 
            int personID, 
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            byte gender, 
            string phone, 
            string email, 
            string address)> GetDoctorByID(int doctorID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Doctor_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DoctorID", doctorID);

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow))
                    {
                        if (await reader.ReadAsync())
                        {
                            return
                                (true,
                                (string)reader["NationalNo"],
                                (int)reader["SpecializationID"],
                                (int)reader["PersonID"],
                                (string)reader["FirstName"],
                                (string)reader["LastName"],
                                (DateTime)reader["DateOfBirth"],
                                (byte)reader["Gender"],
                                (string)reader["Phone"],
                                (string)reader["Email"],
                                (string)reader["Address"]);
                        }

                        return
                            (false, null, -1, -1, null, null, DateTime.MinValue, 0, null, null, null);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                    throw;
                }
            }
        }

        public static bool Update(int doctorID, int specializationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Doctor_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DoctorID", doctorID);
                command.Parameters.AddWithValue("@SpecializationID", specializationID);

                connection.Open();

                try
                {
                    rowsAffected = command.ExecuteNonQuery();
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
