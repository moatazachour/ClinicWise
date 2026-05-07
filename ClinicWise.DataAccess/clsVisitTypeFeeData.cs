using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.VisitTypeFees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsVisitTypeFeeData
    {
        public static int AddNew(
            byte visitType,
            decimal baseAmount,
            DateTime effectiveFrom,
            DateTime? effectiveTo,
            int createdByUserID,
            DateTime createdAt)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("VisitFee_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@VisitType", SqlDbType.TinyInt).Value = visitType;
                command.Parameters.Add("@BaseAmount", SqlDbType.Decimal).Value = baseAmount;
                command.Parameters.Add("@EffectiveFrom", SqlDbType.DateTime).Value = effectiveFrom;
                command.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value =
                    effectiveTo.HasValue ? (object)effectiveTo.Value : DBNull.Value;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
                command.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = createdAt;

                SqlParameter outputParam = new SqlParameter("@VisitFeeID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();

                    return (int)command.Parameters["@VisitFeeID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static bool Update(
            int visitFeeID,
            byte visitType,
            decimal baseAmount,
            DateTime effectiveFrom,
            DateTime? effectiveTo)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("VisitFee_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@VisitFeeID", SqlDbType.Int).Value = visitFeeID;
                command.Parameters.Add("@VisitType", SqlDbType.TinyInt).Value = visitType;
                command.Parameters.Add("@BaseAmount", SqlDbType.Decimal).Value = baseAmount;
                command.Parameters.Add("@EffectiveFrom", SqlDbType.DateTime).Value = effectiveFrom;
                command.Parameters.Add("@EffectiveTo", SqlDbType.DateTime).Value =
                    effectiveTo.HasValue ? (object)effectiveTo.Value : DBNull.Value;

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

        public static async Task<VisitTypeFeeDTO> GetByIDAsync(int visitFeeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("VisitFee_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@VisitFeeID", SqlDbType.Int).Value = visitFeeID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new VisitTypeFeeDTO(
                                visitFeeID,
                                (enVisitType)(byte)reader["VisitType"],
                                (decimal)reader["BaseAmount"],
                                (DateTime)reader["EffectiveFrom"],
                                reader["EffectiveTo"] == DBNull.Value
                                    ? null
                                    : (DateTime?)reader["EffectiveTo"],
                                (int)reader["CreatedByUserID"],
                                (DateTime)reader["CreatedAt"]
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

        public static async Task<List<VisitTypeFeeViewDTO>> GetAllAsync()
        {
            List<VisitTypeFeeViewDTO> visitTypeFees = new List<VisitTypeFeeViewDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("VisitFee_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            visitTypeFees.Add(new VisitTypeFeeViewDTO(
                                (int)reader["VisitFeeID"],
                                (string)reader["VisitTypeLabel"],
                                (decimal)reader["BaseAmount"],
                                (DateTime)reader["EffectiveFrom"],
                                reader["EffectiveTo"] == DBNull.Value
                                    ? null
                                    : (DateTime?)reader["EffectiveTo"],
                                (string)reader["CreatedBy"],
                                (bool)reader["IsActive"]
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

            return visitTypeFees;
        }
    }
}
