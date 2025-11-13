namespace ClinicWise.Contracts.Speciatizations
{
    public class SpecializationDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SpecializationDTO(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }
}
