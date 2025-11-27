using ClinicWise.Contracts.Appointments;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsAppointmentData
    {
        public static int AddNew(int doctorID, int patientID, DateTime? date, byte status, int scheduledByUserID)
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

                    return (int)command.Parameters["@AppointmentID"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static bool Update(int appointmentID, int doctorID, int patientID, DateTime? date, byte status, int scheduledByUserID)
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

        public static async Task<AppointmentDTO> GetByIDAsync(int appointmentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetByID", connection))
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
                            return new AppointmentDTO()
                            {
                                AppointmentID = (int)reader["AppointmentID"],
                                DoctorID = (int)reader["DoctorID"],
                                PatientID = (int)reader["PatientID"],
                                Date = reader["Date"] as DateTime?,
                                Status = (byte)reader["Status"],
                                ScheduledByUserID = (int)reader["ScheduledBy"]
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

        public static async Task<List<AppointmentDisplayDTO>> GetAllAsync()
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetTodaysAsync()
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetTodays", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetTomorrowsAsync()
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetTomorrows", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetThisWeekAppointmentsAsync()
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetThisWeek", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetNextWeekAppointmeentsAsync()
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetNextWeek", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetThisMonthAppointmentsAsync()
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetThisMonth", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetNextMonthAppointmentsAsync()
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetNextMonth", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetByDoctorAsync(int doctorId)
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetByDoctor", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorId;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments
                ;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetNextByDoctorAsync(int doctorId)
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetNextByDoctor", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorId;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments;
        }

        public static async Task<List<AppointmentDisplayDTO>> GetByPatientAsync(int patientID)
        {
            List<AppointmentDisplayDTO> appointments = new List<AppointmentDisplayDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetByPatient", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(
                                new AppointmentDisplayDTO(
                                    (int)reader["AppointmentID"],
                                    (string)reader["DoctorFullLabel"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }

            return appointments;
        }

        public static async Task<AppointmentDisplayDTO> GetDetailedByID(int appointmentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Appointment_GetDetailedByID", connection))
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
                            return new AppointmentDisplayDTO(
                                    appointmentID,
                                    (int)reader["DoctorID"],
                                    (string)reader["DoctorFullLabel"],
                                    (int)reader["PatientID"],
                                    (string)reader["PatientName"],
                                    reader["Date"] as DateTime?,
                                    (string)reader["StatusCaption"],
                                    (string)reader["ScheduledBy"]
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
    }
}