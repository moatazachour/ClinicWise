using ClinicWise.DataAccess;
using System.Data;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsSpecialization
    {
        public int SpecializationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public clsSpecialization()
        {
            SpecializationID = -1;
            Name = string.Empty;
            Description = string.Empty;
        }

        public clsSpecialization(
            int specializationID,
            string name,
            string description)
        {
            SpecializationID = specializationID;
            Name = name;
            Description = description;
        }

        public static async Task<clsSpecialization> FindAsync(int specializationID)
        {
            // I used Tuple here
            var (isFound, name, description) = await clsSpecializationData.GetSpecializationByID(specializationID);

            if (isFound)
                return new clsSpecialization(specializationID, name, description);
            else
                return null;
        }

        public static async Task<clsSpecialization> FindByNameAsync(string name)
        {
            var (isFound, id, description) = await clsSpecializationData.GetSpecializationByName(name);

            if (isFound)
                return new clsSpecialization(id, name, description);
            else
                return null;
        }

        public static async Task<DataTable> GetAllAsync()
        {
            return await clsSpecializationData.GetAllSpecializations();
        }
    }
}
