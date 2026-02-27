namespace ClinicWise.Contracts.PrescriptionItems
{
    public struct stDurationPeriod
    {
        public byte Days;
        public byte Months;

        public override string ToString() => Months > 0 ? $"{Months}M {Days}D" : $"{Days}D";

        // To Database
        public string ToStorageString() => $"{Months}:{Days}";

        // From Database
    }
}
