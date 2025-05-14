namespace Models.Relations
{
    public class Car : Entity
    {
        public string Model { get; set; } = string.Empty;

        public int? RegistrationId { get; set; }
        public Registration? Registration { get; set; }
        public Engine? Engine { get; set; }
        public ICollection<Driver> Drivers { get; set; } = [];
    }
}
