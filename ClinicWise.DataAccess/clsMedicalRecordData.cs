using ClinicWise.Contracts.MedicalRecords;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsMedicalRecordData
    {
        public static int AddNew(
            int appointmentID, byte visitType, string descriptionOfVisit, string diagnosis, string additionalNotes)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("MedicalRecord_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentID;
                command.Parameters.Add("@VisitType", SqlDbType.TinyInt).Value = visitType;
                command.Parameters.Add("@DescriptionOfVisit", SqlDbType.NVarChar).Value = 
                    string.IsNullOrWhiteSpace(descriptionOfVisit) ? (object)DBNull.Value : descriptionOfVisit;
                command.Parameters.Add("@Diagnosis", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(diagnosis) ? (object)DBNull.Value : diagnosis;
                command.Parameters.Add("@AdditionalNotes", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(additionalNotes) ? (object)DBNull.Value : additionalNotes;


                SqlParameter outputIdParam = new SqlParameter("@RecordID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                connection.Open();
                try
                {
                    command.ExecuteNonQuery();

                    return (int)command.Parameters["@RecordID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static async Task<MedicalRecordDTO> GetByAppointmentID(int appointmentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("MedicalRecord_GetByAppointmentID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new MedicalRecordDTO(
                                (int)reader["RecordID"],
                                appointmentID,
                                (byte)reader["VisitType"],
                                (string)reader["DescriptionOfVisit"],
                                (string)reader["Diagnosis"],
                                (string)reader["AdditionalNotes"]
                            );
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static bool Update(
            int recordID, 
            byte visitType, 
            string descriptionOfVisit, 
            string diagnosis, 
            string additionalNotes)
        {
            int rowsAfected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("MedicalRecord_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@RecordID", SqlDbType.Int).Value = recordID;
                command.Parameters.Add("@VisitType", SqlDbType.TinyInt).Value = visitType;
                command.Parameters.Add("@DescriptionOfVisit", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(descriptionOfVisit) ? (object)DBNull.Value : descriptionOfVisit;
                command.Parameters.Add("@Diagnosis", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(diagnosis) ? (object)DBNull.Value : diagnosis;
                command.Parameters.Add("@AdditionalNotes", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(additionalNotes) ? (object)DBNull.Value : additionalNotes;

                connection.Open();

                try
                {
                    rowsAfected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return rowsAfected > 0;
        }
    }
}
