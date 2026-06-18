using System;
using System.Data;
using System.Data.SqlClient;

namespace ClinicWise.DataAccess
{
    public class clsInvoiceReminderData
    {
        public static int AddNew(int invoiceID, byte reminderNumber, string recipientEmail, DateTime sentAt)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("InvoiceReminder_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = invoiceID;
                command.Parameters.Add("@ReminderNumber", SqlDbType.TinyInt).Value = reminderNumber;
                command.Parameters.Add("@RecipientEmail", SqlDbType.VarChar).Value = recipientEmail;
                command.Parameters.Add("@SentAt", SqlDbType.DateTime).Value = sentAt;

                SqlParameter outputParam = new SqlParameter("@InvoiceReminderID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    return (int)command.Parameters["@InvoiceReminderID"].Value;
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
