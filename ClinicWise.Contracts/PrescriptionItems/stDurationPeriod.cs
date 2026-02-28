using System;

namespace ClinicWise.Contracts.PrescriptionItems
{
    public struct stDurationPeriod
    {
        public byte Days;
        public byte Months;

        public override string ToString() => Months > 0 ? $"{Months}M {Days}D" : $"{Days}D";

        public string ToStorageString() => $"{Months}:{Days}";
     
        public static stDurationPeriod FromDatabase(string durationString)
        {
            if (string.IsNullOrWhiteSpace(durationString))
                throw new ArgumentException("Invalid duration format.");

            string[] parts = durationString.Split(':');

            if (parts.Length != 2)
                throw new FormatException("Duration must be in 'Months:Days' format.");


            return new stDurationPeriod {
                Months = Convert.ToByte(parts[0]),
                Days = Convert.ToByte(parts[1])
            };
        }
    }
}
