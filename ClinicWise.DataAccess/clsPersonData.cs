using ClinicWise.Contracts.Persons;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicWise.DataAccess
{
    public class clsPersonData
    {
        public static int AddNewPerson(
            string nationalNo,
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            byte gender, 
            string phone, 
            string email, 
            string address,
            string imagePath,
            int createdByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Person_AddNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NationalNo", SqlDbType.VarChar).Value =
                    string.IsNullOrWhiteSpace(nationalNo) ? (object)DBNull.Value : nationalNo;
                command.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = firstName;
                command.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = lastName;
                command.Parameters.AddWithValue("@DateOfBirth", SqlDbType.DateTime).Value = dateOfBirth;
                command.Parameters.AddWithValue("@Gender", SqlDbType.TinyInt).Value = gender;
                command.Parameters.AddWithValue("@Phone", SqlDbType.TinyInt).Value = phone;
                command.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email;
                command.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(address) ? (object)DBNull.Value : address;
                command.Parameters.AddWithValue("@ImagePath", SqlDbType.NChar).Value =
                    string.IsNullOrWhiteSpace(imagePath) ? (object)DBNull.Value : imagePath;
                command.Parameters.AddWithValue("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                SqlParameter outputParam = new SqlParameter("@PersonID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    object result = command.Parameters["@PersonID"].Value;
                    return result == DBNull.Value ? -1 : (int)result;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw new ApplicationException("Failed to add new person.", ex);
                }
            }
        }

        public static async Task<PersonDTO> GetByID(int personID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Person_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return new PersonDTO
                            {
                                PersonID = personID,
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                NationalNo = reader["NationalNo"] as string,
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Gender = (byte)reader["Gender"],
                                Phone = (string)reader["Phone"],
                                Email = reader["Email"] as string,
                                Address = reader["Address"] as string,
                                ImagePath = reader["ImagePath"] as string,
                                CreatedBy = (int)reader["CreatedByUserID"]
                            };
                        }

                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static async Task<PersonDTO> GetByNationalNo(string nationalNo)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Person_GetByNationalNo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@NationalNo", SqlDbType.VarChar).Value = nationalNo;

                await connection.OpenAsync();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return new PersonDTO
                            {
                                PersonID = (int)reader["PersonID"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                NationalNo = nationalNo,
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Gender = (byte)reader["Gender"],
                                Phone = (string)reader["Phone"],
                                Email = reader["Phone"] as string,
                                Address = reader["Address"] as string,
                                ImagePath = reader["ImagePath"] as string,
                                CreatedBy = (int)reader["CreatedByUserID"]
                            };
                        }

                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw;
                }
            }
        }

        public static bool IsExistByNationalNo(string nationalNo)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Person_IsExistByNationalNo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@NationalNo", SqlDbType.VarChar).Value = nationalNo;

                SqlParameter outputParam = new SqlParameter("@Exists", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(outputParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    isFound = (bool)command.Parameters["@Exists"].Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw new ApplicationException("Failed to ckeck doctor existance", ex);
                }
            }

            return isFound;
        }

        public static bool Update(
            int personID, 
            string nationalNo, 
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            byte gender, 
            string phone, 
            string email, 
            string address,
            string imagePath,
            int createdByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("Person_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.AddWithValue("@NationalNo", SqlDbType.VarChar).Value = nationalNo;
                command.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = firstName;
                command.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = lastName;
                command.Parameters.AddWithValue("@DateOfBirth", SqlDbType.DateTime).Value = dateOfBirth;
                command.Parameters.AddWithValue("@Gender", SqlDbType.TinyInt).Value = gender;
                command.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = phone ?? (object)DBNull.Value;
                command.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = email ?? (object)DBNull.Value;
                command.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(address) ? (object)DBNull.Value : address;
                command.Parameters.AddWithValue("@ImagePath", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(imagePath) ? (object)DBNull.Value : imagePath;
                command.Parameters.AddWithValue("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                SqlParameter returnedParam = new SqlParameter("@ReturnVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                command.Parameters.Add(returnedParam);

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    
                    rowsAffected = (int)returnedParam.Value;
                }
                catch (Exception ex)
                {
                    clsGlobal.LogError(ex);
                    throw new ApplicationException("Failed to update new person.", ex);
                }
            }

            return rowsAffected > 0;
        }
    }
}
