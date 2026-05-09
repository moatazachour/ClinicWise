using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.InvoiceItems;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsInvoiceItemData
    {
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
                                VisitFeeID = (int)reader["VisitFeeID"]
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
    }
}
