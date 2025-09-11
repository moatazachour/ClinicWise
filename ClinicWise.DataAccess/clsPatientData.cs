using ClinicWise.Contracts.Patients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsPatientData
    {
        public static async Task<int> AddNewAsync(int personID, int? guardianID)
        {
            int patientID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Patient_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

                if (guardianID.HasValue)
                    command.Parameters.Add("@GuardianID", SqlDbType.Int).Value = guardianID.Value;
                else
                    command.Parameters.Add("@GuardianID", SqlDbType.Int).Value = DBNull.Value;

                SqlParameter outputParam = new SqlParameter("@PatientID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(outputParam);

                await connection.OpenAsync();

                try
                {
                    await command.ExecuteNonQueryAsync();

                    patientID = (int)command.Parameters["@PatientID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return patientID;
        }

        public async static Task<bool> UpdateAsync(int patientID, int? guardianID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Patient_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
                
                if (guardianID.HasValue)
                    command.Parameters.Add("@GuardianID", SqlDbType.Int).Value = guardianID;
                else
                    command.Parameters.Add("@GuardianID", SqlDbType.Int).Value = DBNull.Value;

                await connection.OpenAsync();

                try
                {
                    rowsAffected = await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }

                return rowsAffected > 0;
            }
        }

        public async static Task<List<PatientDisplayDTO>> GetAllAsync()
        {
            List<PatientDisplayDTO> patients = new List<PatientDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Patient_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                                patients.Add(new PatientDisplayDTO
                                {
                                    PatientID = (int)reader["PatientID"],
                                    FullName = (string)reader["FullName"],
                                    NationalNo = (string)reader["NationalNo"],
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    GenderCaption = (string)reader["Gender"],
                                    Phone = (string)reader["Phone"],
                                    Email = (string)reader["Email"],
                                    Address = (string)reader["Address"]
                                });
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }

                return patients;
            }
        }

        public static async Task<PatientDTO> GetByID(int patientID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Patient_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new PatientDTO
                            {
                                PatientID = patientID,
                                PersonID = (int)reader["PersonID"],
                                NationalNo = (string)reader["NationalNo"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Gender = (byte)reader["Gender"],
                                Phone = (string)reader["Phone"],
                                Email = (string)reader["Email"],
                                Address = (string)reader["Address"],
                                ImagePath = (string)reader["ImagePath"],
                                CreatedByUserID = (int)reader["CreatedByUserID"],
                                GuardianID = reader["GuardianID"] == DBNull.Value
                                                ? (int?)null
                                                : (int)reader["GuardianID"]
                            };
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
