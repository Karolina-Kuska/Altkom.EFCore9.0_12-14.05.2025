namespace Models.Relations
{
    public class Registration
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Car Car { get; set; }
    }
}