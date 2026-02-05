using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.Medicaments;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsMedicamentData
    {
        public static int AddNew(string name, string brand, byte dosageForm)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Medicament_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@Brand", SqlDbType.VarChar).Value = brand;
                command.Parameters.Add("@DosageForm", SqlDbType.TinyInt).Value = dosageForm;

                SqlParameter outputParam = new SqlParameter("@MedicamentID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@MedicamentID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static async Task<List<MedicamentDTO>> GetAllAsync()
        {
            List<MedicamentDTO> medicaments = new List<MedicamentDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Medicament_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            medicaments.Add(new MedicamentDTO(
                                (int)reader["MedicamentID"],
                                (string)reader["Name"],
                                (string)reader["Brand"],
                                (enDosageForm)(byte)reader["DosageForm"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }

                return medicaments;
            }
        }

        public static async Task<MedicamentDTO> GetByID(int medicamentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Medicament_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("MedicamentID", SqlDbType.Int).Value = medicamentID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new MedicamentDTO(
                                (int)reader["MedicamentID"],
                                (string)reader["Name"],
                                reader["Brand"] as string,
                                (enDosageForm)(byte)reader["DosageForm"]);
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

        public static bool Update(int medicamentID, string name, string brand, byte dosageForm)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Medicament_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@MedicamentID", SqlDbType.Int).Value = medicamentID;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@Brand", SqlDbType.VarChar).Value = brand;
                command.Parameters.Add("@DosageForm", SqlDbType.TinyInt).Value = dosageForm;

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
