namespace Models
{
    public class Address
    {
        //wg konwencji EF Core klucz jest identyfikowany przez nazwę właściwości: Id lub {NazwaKlasy}Id
        public int AddressId { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
    }
}
