namespace PersonManagement.Shared.DTOs
{
    public class PersonReadDto
    {
        public int ID { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public int NationalityID { get; set; }
        public string NationalityName { get; set; } = null!;
    }
}
