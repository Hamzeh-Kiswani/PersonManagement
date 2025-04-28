namespace PersonManagement.Api.Data.Entities
{
    public class Person
    {
        public int ID { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public int NationalityID { get; set; }
        public Nationality? Nationality { get; set; }
    }
}
