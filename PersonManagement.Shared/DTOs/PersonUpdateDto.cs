namespace PersonManagement.Shared.DTOs
{
    public class PersonUpdateDto
    {
        public int ID { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public int NationalityID { get; set; }
    }
}
