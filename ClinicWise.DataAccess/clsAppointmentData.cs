using System;
using System.Data;
using System.Data.SqlClient;

namespace ClinicWise.DataAccess
{
    public class clsAppointmentData
    {
        public static int AddNew(int doctorID, int patientID, DateTime date, byte status, int scheduledByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorID;
                command.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
                command.Parameters.Add("@Date", SqlDbType.DateTime).Value = date;
                command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = status;
                command.Parameters.Add("@ScheduledBy", SqlDbType.Int).Value = scheduledByUserID;

                SqlParameter outputParam = new SqlParameter("@AppointmentID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    return (int)command.Parameters["AppointmentID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static bool Update(int appointmentID, int doctorID, int patientID, DateTime date, byte status, int scheduledByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@AppointmentID", SqlDbType.Int).Value = appointmentID;
                command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorID;
                command.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
                command.Parameters.Add("@Date", SqlDbType.DateTime).Value = date;
                command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = status;
                command.Parameters.Add("@ScheduledBy", SqlDbType.Int).Value = scheduledByUserID;

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
