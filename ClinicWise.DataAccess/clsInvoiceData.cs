using ClinicWise.Contracts.Appointments;
using ClinicWise.Contracts.Invoices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsInvoiceData
    {
        public static async Task<List<InvoiceViewDTO>> GetAllAsync()
        {
            List<InvoiceViewDTO> invoices = new List<InvoiceViewDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Invoice_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            invoices.Add(new InvoiceViewDTO()
                            {
                                InvoiceID = (int)reader["InvoiceID"],
                                InvoiceNumber = (string)reader["InvoiceNumber"],
                                AppointmentID = (int)reader["AppointmentID"],
                                PatientID = (int)reader["PatientID"],
                                PatientName = (string)reader["PatientName"],
                                TotalAmount = (decimal)reader["TotalAmount"],
                                AmountPaid = (decimal)reader["AmountPaid"],
                                OutstandingBalance = reader["OutstandingBalance"] as decimal?,
                                Status = (enInvoiceStatus)(byte)reader["Status"],
                                StatusLabel = (string)reader["StatusLabel"],
                                IssuedBy = reader["IssuedBy"] as string,
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }

                return invoices;
            }
        }
        

        public static async Task<InvoiceDTO> GetByAppointmentIdAndStatusAsync(int appointmentID, byte status)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Invoice_GetByAppointmentAndStatus", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentID;
                command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = status;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new InvoiceDTO()
                            {
                                InvoiceID = (int)reader["InvoiceID"],
                                InvoiceNumber = (string)reader["InvoiceNumber"],
                                AppointmentID = appointmentID,
                                PatientID = (int)reader["PatientID"],
                                SubTotal = (decimal)reader["SubTotal"],
                                TotalAmount = (decimal)reader["TotalAmount"],
                                Status = (enInvoiceStatus)(byte)status,
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
