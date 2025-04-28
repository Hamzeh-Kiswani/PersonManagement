namespace PersonManagement.Api.Data.Entities
{
    public class Nationality
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Person>? Persons { get; set; }
    }

}
