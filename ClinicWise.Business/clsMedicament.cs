using ClinicWise.Contracts.MedicalRecords;
using ClinicWise.Contracts.Medicaments;
using ClinicWise.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsMedicament
    {
        public enum enMode { AddNew, Update }
        public enMode Mode;


        public int MedicamentID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public enDosageForm DosageForm { get; set; }

        public clsMedicament() 
        {
            MedicamentID = -1;
            Name = null;
            Brand = null;
            DosageForm = enDosageForm.Tablet;

            Mode = enMode.AddNew;
        }

        public clsMedicament(int id, string name, string brand, enDosageForm dosageForm)
        {
            MedicamentID = id;
            Name = name;
            Brand = brand;
            DosageForm = dosageForm;

            Mode = enMode.Update;
        }

        public clsMedicament(MedicamentDTO medicamentDTO)
        {
            MedicamentID = medicamentDTO.MedicamentID;
            Name = medicamentDTO.Name;
            Brand = medicamentDTO.Brand;
            DosageForm = medicamentDTO.DosageForm;

            Mode = enMode.Update;
        }

        public static async Task<List<MedicamentDTO>> GetAllAsync()
        {
            return await clsMedicamentData.GetAllAsync();
        }

        public static async Task<MedicamentDTO> FindAsync(int medicamentID)
        {
            return await clsMedicamentData.GetByID(medicamentID);
        }

        private bool _AddNew()
        {
            MedicamentID = clsMedicamentData.AddNew(Name, Brand, (byte)DosageForm);

            return MedicamentID != -1;
        }

        private bool _Update()
        {
            return clsMedicamentData.Update(MedicamentID, Name, Brand, (byte)DosageForm);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
                default:
                    return false;
            }
        }
    }
}
