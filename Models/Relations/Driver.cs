
namespace Models.Relations
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Car { get; set; } = [];
    }
}
