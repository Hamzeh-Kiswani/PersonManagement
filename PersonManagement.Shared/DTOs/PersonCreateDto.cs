using System.ComponentModel.DataAnnotations;

namespace PersonManagement.Shared.DTOs
{
    public class PersonCreateDto
    {
        [Required]
        public string FullName { get; set; } = null!;
       
        [Range(1, 120)]
        public int Age { get; set; }
        
        [Required]
        public int NationalityID { get; set; }
    }
}
