namespace Models.Relations
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;

        public int? RegistrationId { get; set; }
        public Registration? Registration { get; set; }
        public Engine? Engine { get; set; }
    }
}
