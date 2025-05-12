namespace Models
{
    public class Person
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public ulong PESEL { get; set; }

        public Address_? Address { get; set; }
    }
}
