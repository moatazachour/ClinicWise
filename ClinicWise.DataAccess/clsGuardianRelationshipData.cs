using ClinicWise.Contracts.Guardians;
using ClinicWise.Contracts.Patients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsGuardianRelationshipData
    {
        public static async Task<List<GuardianRelationshipDTO>> GetAllAsync()
        {
            List<GuardianRelationshipDTO> guardianRelationships = new List<GuardianRelationshipDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("GuardianRelationship_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            guardianRelationships.Add(new GuardianRelationshipDTO
                            {
                                GuardianRelationshipID = (int)reader["GuardianRelationshipID"],
                                RelationshipName = (string)reader["Name"],
                                RelationshipDescription = (string)reader["Description"],
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }

                return guardianRelationships;
            }
        }

        public static async Task<GuardianRelationshipDTO> GetByID(int guardianID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("GuardianRelationship_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@RelationshipID", SqlDbType.Int).Value = guardianID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new GuardianRelationshipDTO
                            {
                                GuardianRelationshipID = guardianID,
                                RelationshipName = (string)reader["Name"],
                                RelationshipDescription = (string)reader["Description"]
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

        public static GuardianRelationshipDTO GetByRelationshipName(string relationshipName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("GuardianRelationship_GetByName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@RelationshipName", SqlDbType.NVarChar).Value = relationshipName;

                connection.Open();

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new GuardianRelationshipDTO
                            {
                                GuardianRelationshipID = (int)reader["GuardianRelationshipID"],
                                RelationshipName = relationshipName,
                                RelationshipDescription = (string)reader["Description"]
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
