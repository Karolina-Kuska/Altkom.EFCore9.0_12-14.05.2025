namespace Models
{
    public class Person
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public ulong PESEL { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public string FullName { get; } //=> $"{Name} {LastName}";

        public Address? Address { get; set; }
    }
}
