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
        public static int AddNew(int personID, int? guardianID)
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

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();

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

        public static bool Update(int patientID, int? guardianID)
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

                connection.Open();

                try
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }

                return rowsAffected > 0;
            }
        }

        public static async Task<List<PatientDisplayDTO>> GetAllAsync()
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
                                    NationalNo = reader["NationalNo"] as string,
                                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                                    GenderCaption = (string)reader["Gender"],
                                    Phone = (string)reader["Phone"],
                                    Email = reader["Email"] as string,
                                    Address = reader["Address"] as string
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
                                NationalNo = reader["NationalNo"] as string,
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Gender = (byte)reader["Gender"],
                                Phone = reader["Phone"] as string,
                                Email = reader["Email"] as string,
                                Address = reader["Address"] as string,
                                ImagePath = reader["ImagePath"] == DBNull.Value
                                                ? null
                                                : (string)reader["ImagePath"],
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

        public static bool Delete(int patientID, int deletedByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Patient_Delete", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
                command.Parameters.Add("@DeletedByUserID", SqlDbType.Int).Value = deletedByUserID;

                SqlParameter outputParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(outputParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();

                    rowsAffected = outputParam.Value != null ? (int)command.Parameters["@RowsAffected"].Value : 0;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    return false;
                }
            }

            return (rowsAffected > 0);
        }
    }
}
