using System.Configuration;

namespace ClinicWise.DataAccess
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = 
            ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
    }
}
