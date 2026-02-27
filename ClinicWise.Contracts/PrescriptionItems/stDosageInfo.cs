namespace ClinicWise.Contracts.PrescriptionItems
{
    public struct stDosageInfo
    {
        public string Dosage {  get; set; }
        public string Frequency;
        public stDurationPeriod Duration;
        public string SpecialInstruction;
        public bool IsForever;

        public string DurationDisplay
            => IsForever ? "Ongoing" : Duration.ToString();
    }
}
