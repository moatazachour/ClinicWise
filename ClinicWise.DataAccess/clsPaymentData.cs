using ClinicWise.Contracts.Invoices;
using ClinicWise.Contracts.Medicaments;
using ClinicWise.Contracts.Payments;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicWise.DataAccess
{
    public class clsPaymentData
    {
        public static int AddNew(
            int invoiceID, 
            DateTime paymentDate, 
            enPaymentMethod method, 
            decimal amountPaid, 
            int recordedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Payment_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = invoiceID;
                command.Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = paymentDate;
                command.Parameters.Add("@Method", SqlDbType.TinyInt).Value = (byte)method;
                command.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = amountPaid;
                command.Parameters.Add("@RecordedByUserID", SqlDbType.Int).Value = recordedByUserID;

                SqlParameter outputParam = new SqlParameter("@PaymentID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@PaymentID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static async Task<List<PaymentViewDTO>> GetAllAsync()
        {
            List<PaymentViewDTO> payments = new List<PaymentViewDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Payment_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            payments.Add(new PaymentViewDTO()
                            {
                                PaymentID = (int)reader["PaymentID"],
                                InvoiceID = (int)reader["InvoiceID"],
                                InvoiceNumber = (string)reader["InvoiceNumber"],
                                PaymentDate = (DateTime)reader["PaymentDate"],
                                Method = (enPaymentMethod)(byte)reader["Method"],
                                MethodLabel = (string)reader["MethodLabel"],
                                AmountPaid = (decimal)reader["AmountPaid"],
                                RecordedByUserID = (int)reader["RecordedByUserID"],
                                RecordedBy = (string)reader["RecordedBy"],
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }

                return payments;
            }
        }

        public static async Task<PaymentDTO> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Payment_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PaymentID", SqlDbType.Int).Value = id;
                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new PaymentDTO()
                            {
                                PaymentID = id,
                                InvoiceID = (int)reader["InvoiceID"],
                                PaymentDate = (DateTime)reader["PaymentDate"],
                                Method = (enPaymentMethod)(byte)reader["Method"],
                                AmountPaid = (decimal)reader["AmountPaid"],
                                RecordedByUserID = (int)reader["RecordedByUserID"],
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
            int paymentID, 
            DateTime paymentDate, 
            enPaymentMethod method, 
            decimal amountPaid, 
            int recordedByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Payment_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PaymentID", SqlDbType.Int).Value = paymentID;
                command.Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = paymentDate;
                command.Parameters.Add("@Method", SqlDbType.TinyInt).Value = (byte)method;
                command.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = amountPaid;
                command.Parameters.Add("@RecordedByUserID", SqlDbType.Int).Value = recordedByUserID;

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
