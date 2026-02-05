namespace ClinicWise.Contracts.Medicaments
{
    public class MedicamentDTO
    {
        public int MedicamentID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public enDosageForm DosageForm { get; set; }

        public MedicamentDTO(int medicamentID, string name, string brand, enDosageForm dosageForm)
        {
            MedicamentID = medicamentID;
            Name = name;
            Brand = brand;
            DosageForm = dosageForm;
        }
    }
}
