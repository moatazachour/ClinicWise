using System;
using System.Data;
using System.Data.SqlClient;

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

                command.Parameters.Add("@Name", SqlDbType.Int).Value = name;
                command.Parameters.Add("@Brand", SqlDbType.Int).Value = brand;
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
