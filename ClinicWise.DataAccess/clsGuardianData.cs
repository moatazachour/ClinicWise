using ClinicWise.Contracts.Guardians;
using ClinicWise.Contracts.Patients;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsGuardianData
    {
        public static int AddNew(int personID, int relationshipID)
        {
            int guardianID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Guardian_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@RelationshipID", SqlDbType.Int).Value = relationshipID;

                SqlParameter outputParam = new SqlParameter("@GuardianID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(outputParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();

                    guardianID = (int)command.Parameters["@GuardianID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return guardianID;
        }

        public static bool Update(int guardianID, int relationshipID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Guardian_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@GuardianID", SqlDbType.Int).Value = guardianID;
                command.Parameters.Add("@RelationshipID", SqlDbType.Int).Value = relationshipID;

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

        public static async Task<GuardianDTO> GetByID(int guardianID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Guardian_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@GuardianID", SqlDbType.Int).Value = guardianID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new GuardianDTO
                            (
                                guardianID,
                                (int)reader["PersonID"],
                                (string)reader["NationalNo"],
                                (string)reader["FirstName"],
                                (string)reader["LastName"],
                                (DateTime)reader["DateOfBirth"],
                                (byte)reader["Gender"],
                                reader["Phone"] as string,
                                reader["Email"] as string,
                                reader["Address"] as string,
                                reader["ImagePath"] as string,
                                (int)reader["RelationshipID"],
                                (int)reader["CreatedByUserID"]
                            );
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
