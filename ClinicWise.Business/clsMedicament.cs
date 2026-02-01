using ClinicWise.DataAccess;

namespace ClinicWise.Business
{
    public class clsMedicament
    {
        public enum enMode { AddNew, Update }
        public enMode Mode;

        public enum enDosageForm
        {
            Tablet = 1,
            Capsule = 2,
            Syrup = 3,
            Suspension = 4,
            Solution = 5,
            Injection = 6,
            Drops = 7,
            Cream = 8,
            Ointment = 9,
            Gel = 10,
            Lotion = 11,
            Spray = 12,
            Inhaler = 13,
            Patch = 14,
            Suppository = 15,
            Powder = 16,
            Granules = 17,
            Lozenge = 18,
            Foam = 19,
            Shampoo = 20,
            NasalSpray = 21,
            EyeDrops = 22,
            EarDrops = 23
        }

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
