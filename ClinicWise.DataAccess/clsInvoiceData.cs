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

        public static async Task<InvoiceDTO> GetByIDAsync(int invoiceID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Invoice_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = invoiceID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new InvoiceDTO()
                            {
                                InvoiceID = invoiceID,
                                InvoiceNumber = (string)reader["InvoiceNumber"],
                                AppointmentID = (int)reader["AppointmentID"],
                                PatientID = (int)reader["PatientID"],
                                SubTotal = (decimal)reader["SubTotal"],
                                DiscountAmount = (decimal)reader["DiscountAmount"],
                                DiscountPercent = reader["DiscountPercent"] as decimal?,
                                DiscountType = reader["DiscountType"] == DBNull.Value ? null : (enDiscountType?)(byte)reader["DiscountType"],
                                DiscountAuthorizedByUserID = reader["DiscountAuthorizedByUserID"] as int?,
                                TotalAmount = (decimal)reader["TotalAmount"],
                                AmountPaid = (decimal)reader["AmountPaid"],
                                OutstandingBalance = reader["OutstandingBalance"] as decimal?,
                                Status = (enInvoiceStatus)(byte)reader["Status"],
                                IssuedByUserID = reader["IssuedByUserID"] as int?,
                                IssuedAt = reader["IssuedAt"] as DateTime?,
                                VoidedByUserID = reader["VoidedByUserID"] as int?,
                                VoidedAt = reader["VoidedAt"] as DateTime?,
                                VoidReason = reader["VoidReason"] as string,
                                Notes = reader["Notes"] as string,
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

        public static async Task<InvoiceDTO> GetLatestInvoiceByAppointmentIdAsync(int appointmentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Invoice_GetLatestInvoiceByAppointmentID", connection))
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
                            return new InvoiceDTO()
                            {
                                InvoiceID = (int)reader["InvoiceID"],
                                InvoiceNumber = (string)reader["InvoiceNumber"],
                                AppointmentID = appointmentID,
                                PatientID = (int)reader["PatientID"],
                                SubTotal = (decimal)reader["SubTotal"],
                                DiscountAmount = (decimal)reader["DiscountAmount"],
                                DiscountPercent = reader["DiscountPercent"] as decimal?,
                                DiscountType = reader["DiscountType"] == DBNull.Value ? null : (enDiscountType?)(byte)reader["DiscountType"],
                                DiscountAuthorizedByUserID = reader["DiscountAuthorizedByUserID"] as int?,
                                TotalAmount = (decimal)reader["TotalAmount"],
                                AmountPaid = (decimal)reader["AmountPaid"],
                                OutstandingBalance = reader["OutstandingBalance"] as decimal?,
                                Status = (enInvoiceStatus)(byte)reader["Status"],
                                IssuedByUserID = reader["IssuedByUserID"] as int?,
                                IssuedAt = reader["IssuedAt"] as DateTime?,
                                VoidedByUserID = reader["VoidedByUserID"] as int?,
                                VoidedAt = reader["VoidedAt"] as DateTime?,
                                VoidReason = reader["VoidReason"] as string,
                                Notes = reader["Notes"] as string,
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

        public static bool Update(
            int invoiceID, 
            decimal subTotal, 
            decimal discountAmount, 
            decimal? discountPercent, 
            enDiscountType? discountType, 
            int? discountAuthorizedByUserID, 
            decimal totalAmount, 
            decimal amountPaid, 
            decimal? outstandingBalance, 
            enInvoiceStatus status, 
            int? issuedByUserID, 
            DateTime? issuedAt,
            int? voidedByUserID,
            DateTime? voidedAt,
            string voidReason,
            string notes)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Invoice_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = invoiceID;
                command.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = subTotal;
                command.Parameters.Add("@DiscountAmount", SqlDbType.Decimal).Value = discountAmount;
                command.Parameters.Add("@DiscountPercent", SqlDbType.Decimal).Value = (object)discountPercent ?? DBNull.Value;
                command.Parameters.Add("@DiscountType", SqlDbType.TinyInt).Value = discountType.HasValue ? (object)(byte)discountType.Value : DBNull.Value;
                command.Parameters.Add("@DiscountAuthorizedByUserID", SqlDbType.Int).Value = (object)discountAuthorizedByUserID ?? DBNull.Value;
                command.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = totalAmount;
                command.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = amountPaid;
                command.Parameters.Add("@OutstandingBalance", SqlDbType.Decimal).Value = (object)outstandingBalance ?? DBNull.Value;
                command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = (byte)status;
                command.Parameters.Add("@IssuedByUserID", SqlDbType.Int).Value = (object)issuedByUserID ?? DBNull.Value;
                command.Parameters.Add("@IssuedAt", SqlDbType.DateTime).Value = (object)issuedAt ?? DBNull.Value;
                command.Parameters.Add("@VoidedByUserID", SqlDbType.Int).Value = (object)voidedByUserID ?? DBNull.Value;
                command.Parameters.Add("@VoidedAt", SqlDbType.DateTime).Value = (object)voidedAt ?? DBNull.Value;
                command.Parameters.Add("@VoidReason", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(voidReason) ? DBNull.Value : (object)voidReason;

                command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(notes) ? DBNull.Value : (object)notes;

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
