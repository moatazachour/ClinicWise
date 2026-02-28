using ClinicWise.Contracts.Medicaments;
using ClinicWise.Contracts.PrescriptionItems;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsPrescriptionItemData
    {
        public static int AddNew(int medicalRecordID, int medicamentID, stDosageInfo dosageInfo)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("PrescriptionItem_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@RecordID", SqlDbType.Int).Value = medicalRecordID;
                command.Parameters.Add("@MedicamentID", SqlDbType.Int).Value = medicamentID;
                command.Parameters.Add("@Dosage", SqlDbType.VarChar).Value = dosageInfo.Dosage;
                command.Parameters.Add("@Frequency", SqlDbType.VarChar).Value = dosageInfo.Frequency;
                command.Parameters.Add("@Duration", SqlDbType.VarChar).Value = dosageInfo.Duration.ToStorageString();
                command.Parameters.Add("@SpecialInstruction", SqlDbType.VarChar).Value = dosageInfo.SpecialInstruction;
                command.Parameters.Add("@IsForever", SqlDbType.Bit).Value = dosageInfo.IsForever;

                SqlParameter outputParam = new SqlParameter("@PrescriptionItemID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();

                    return (int)command.Parameters["@PrescriptionItemID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static bool AddNewItems(List<PrescriptionItemsCreateDTO> prescriptionItemDTOs)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (PrescriptionItemsCreateDTO prescriptionItem in prescriptionItemDTOs)
                    {
                        using (SqlCommand command = new SqlCommand("PrescriptionItem_AddNew", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Add("@RecordID", SqlDbType.Int).Value = prescriptionItem.MedicalRecordID;
                            command.Parameters.Add("@MedicamentID", SqlDbType.Int).Value = prescriptionItem.MedicamentID;
                            command.Parameters.Add("@Dosage", SqlDbType.VarChar).Value = prescriptionItem.DosageInfo.Dosage;
                            command.Parameters.Add("@Frequency", SqlDbType.VarChar).Value = prescriptionItem.DosageInfo.Frequency;
                            command.Parameters.Add("@Duration", SqlDbType.VarChar).Value = prescriptionItem.DosageInfo.Duration.ToStorageString();
                            command.Parameters.Add("@SpecialInstruction", SqlDbType.VarChar).Value = prescriptionItem.DosageInfo.SpecialInstruction;
                            command.Parameters.Add("@IsForever", SqlDbType.Bit).Value = prescriptionItem.DosageInfo.IsForever;

                            SqlParameter outputParam = new SqlParameter("@PrescriptionItemID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            command.Parameters.Add(outputParam);

                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static async Task<List<PrescriptionItemDisplayDTO>> GetAllByMedicalRecordAsync(int medicalRecordID)
        {
            List<PrescriptionItemDisplayDTO> prescriptionItems = new List<PrescriptionItemDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("PrescriptionItem_GetAllByMedicalRecord", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MedicalRecordID", SqlDbType.Int).Value = medicalRecordID;
                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            prescriptionItems.Add(new PrescriptionItemDisplayDTO(
                                (int)reader["ItemID"],
                                (int)reader["RecordID"],
                                (int)reader["MedicamentID"],
                                (string)reader["Brand"],
                                (string)reader["Name"],
                                (enDosageForm)(byte)reader["DosageForm"],
                                new stDosageInfo
                                {
                                    Dosage = (string)reader["Dosage"],
                                    Frequency = (string)reader["Frequency"],
                                    Duration = stDurationPeriod.FromDatabase((string)reader["Duration"]),
                                    SpecialInstruction = (string)reader["SpecialInstruction"],
                                    IsForever = (bool)reader["IsForever"]
                                }
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return prescriptionItems;
        }

        public static bool Update(int itemID, int medicalRecordID, int medicamentID, stDosageInfo dosageInfo)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("PrescriptionItem_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PrescriptionItemID", SqlDbType.Int).Value = itemID;
                command.Parameters.Add("@RecordID", SqlDbType.Int).Value = medicalRecordID;
                command.Parameters.Add("@MedicamentID", SqlDbType.Int).Value = medicamentID;
                command.Parameters.Add("@Dosage", SqlDbType.VarChar).Value = dosageInfo.Dosage;
                command.Parameters.Add("@Frequency", SqlDbType.VarChar).Value = dosageInfo.Frequency;
                command.Parameters.Add("@IsForever", SqlDbType.Bit).Value = dosageInfo.IsForever;
                
                if (dosageInfo.IsForever)
                    command.Parameters.Add("@Duration", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Duration", SqlDbType.VarChar).Value = dosageInfo.Duration.ToStorageString();
                
                command.Parameters.Add("@SpecialInstruction", SqlDbType.VarChar).Value = dosageInfo.SpecialInstruction;

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
            }

            return rowsAffected > 0;
        }
    }
}