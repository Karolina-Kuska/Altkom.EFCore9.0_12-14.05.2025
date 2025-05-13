namespace Models.Relations
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;

        public Registration? Registration { get; set; }
    }
}
