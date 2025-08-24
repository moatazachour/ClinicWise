using ClinicWise.Contracts;
using System;
using System.Collections.Generic;
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

                command.Parameters.AddWithValue("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.AddWithValue("@SpecializationID", SqlDbType.Int).Value = specializationID;

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
                    clsGlobal.LogError(ex);
                    throw new ApplicationException("Failed to add new doctor.", ex);
                }
            }
        }

        public static async Task<List<DoctorDisplayDTO>> GetAllDoctors()
        {
            List<DoctorDisplayDTO> doctors = new List<DoctorDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Doctor_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            doctors.Add(new DoctorDisplayDTO
                            {
                                DoctorID = (int)reader["DoctorID"],
                                FullName = (string)reader["FullName"],
                                NationalNo = (string)reader["NationalNo"],
                                Specialization = (string)reader["Specialization"],
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
                    throw new ApplicationException("Failed to retrieve doctors data", ex);
                }
            }

            return doctors;
        }

        public static async Task<DoctorDTO> GetDoctorByID(int doctorID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Doctor_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DoctorID", SqlDbType.Int).Value = doctorID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow))
                    {
                        if (await reader.ReadAsync())
                        {
                            return new DoctorDTO
                            {
                                DoctorID = doctorID,
                                NationalNo = (string)reader["NationalNo"],
                                SpecializationID = (int)reader["SpecializationID"],
                                PersonID = (int)reader["PersonID"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Gender = (byte)reader["Gender"],
                                Phone = (string)reader["Phone"],
                                Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"],
                                Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"],
                                ImagePath = reader["ImagePath"] == DBNull.Value ? null : (string)reader["ImagePath"],
                                CreatedByUserID = (int)reader["CreatedByUserID"]
                            };
                        }

                        return null;
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw new ApplicationException("Failed to retrieve doctor data", ex);
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

                command.Parameters.AddWithValue("@DoctorID", SqlDbType.Int).Value = doctorID;
                command.Parameters.AddWithValue("@SpecializationID", SqlDbType.Int).Value = specializationID;

                connection.Open();

                try
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw new ApplicationException("Failed to update doctor data", ex);
                }
            }

            return rowsAffected > 0;
        }

        public static bool Delete(int doctorID, int deletedByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Doctor_Delete", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DoctorID", SqlDbType.Int).Value = doctorID;
                command.Parameters.AddWithValue("@DeletedByUserID", SqlDbType.Int).Value = deletedByUserID;

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
                    throw new ApplicationException("Failed to delete doctor data", ex);
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsExistByNationalNo(string nationalNo)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Doctor_IsExistByNationalNo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NationalNo", SqlDbType.VarChar).Value = nationalNo;

                SqlParameter outputParam = new SqlParameter("@Exists", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(outputParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery ();
                    isFound = (bool)command.Parameters["@Exists"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw new ApplicationException("Failed to ckeck doctor existance", ex);
                }
            }

            return isFound;
        }
    }
}
