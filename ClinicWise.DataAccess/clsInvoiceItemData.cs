using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.InvoiceItems;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsInvoiceItemData
    {
        public static int AddNew(int invoiceID, string description, int quantity, decimal unitPrice, decimal totalPrice)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("InvoiceItem_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = invoiceID;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                command.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = unitPrice;
                command.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = totalPrice;

                SqlParameter outputParam = new SqlParameter("@ItemID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    return (int)command.Parameters["@ItemID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static async Task<List<InvoiceItemDTO>> GetAllByInvoiceAsync(int invoiceID)
        {
            List<InvoiceItemDTO> invoiceItems = new List<InvoiceItemDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("InvoiceItem_GetByInvoice", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = invoiceID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            invoiceItems.Add(new InvoiceItemDTO()
                            {
                                ItemID = (int)reader["ItemID"],
                                InvoiceID = (int)reader["InvoiceID"],
                                Description = reader["Description"] as string,
                                Quantity = (int)reader["Quantity"],
                                UnitPrice = (decimal)reader["UnitPrice"],
                                TotalPrice = (decimal)reader["TotalPrice"],
                                VisitFeeID = reader["VisitFeeID"] as int?
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return invoiceItems;
        }

        public static async Task<InvoiceItemDTO> GetByIdAsync(int invoiceItemID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("InvoiceItem_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ItemID", SqlDbType.Int).Value = invoiceItemID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new InvoiceItemDTO()
                            {
                                ItemID = (int)reader["ItemID"],
                                InvoiceID = (int)reader["InvoiceID"],
                                Description = reader["Description"] as string,
                                Quantity = (int)reader["Quantity"],
                                UnitPrice = (decimal)reader["UnitPrice"],
                                TotalPrice = (decimal)reader["TotalPrice"],
                                VisitFeeID = reader["VisitFeeID"] as int?
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

        public static bool Update(int itemID, int invoiceID, string description, int quantity, decimal unitPrice, decimal totalPrice)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("InvoiceItem_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ItemID", SqlDbType.Int).Value = itemID;
                command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = invoiceID;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                command.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = unitPrice;
                command.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = totalPrice;

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

        public static bool Delete(int itemID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("InvoiceItem_Delete", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ItemID", SqlDbType.Int).Value = itemID;

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
