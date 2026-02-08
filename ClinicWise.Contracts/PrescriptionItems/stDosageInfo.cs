namespace ClinicWise.Contracts.PrescriptionItems
{
    public struct stDosageInfo
    {
        public string Dosage;
        public string Frequency;
        public stDurationPeriod Duration;
        public bool IsForever;

        public string DurationDisplay
            => IsForever ? "Ongoing" : Duration.ToString();
    }
}
