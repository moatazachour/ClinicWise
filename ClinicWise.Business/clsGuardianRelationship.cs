using ClinicWise.Contracts.Guardians;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsGuardianRelationship
    {
        public int GuardianRelationshipID { get; set; }
        public string RelationshipName { get; set; }
        public string RelationshipDescription { get; set; }

        public static async Task<GuardianRelationshipDTO> FindAsync(int guardianID)
        {
            return await clsGuardianRelationshipData.GetByID(guardianID);
        }

        public static GuardianRelationshipDTO FindByName(string relationshipName)
        {
            return clsGuardianRelationshipData.GetByRelationshipName(relationshipName);
        }

        public static async Task<List<GuardianRelationshipDTO>> GetAllAsync()
        {
            return await clsGuardianRelationshipData.GetAllAsync();
        }
    }
}
