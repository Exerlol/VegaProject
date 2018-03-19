using System.ComponentModel.DataAnnotations;

namespace VegaProject.Controllers.Resources_DTOs
{
    public class ContactResource
    {
        [Required]
        [MaxLength(255)]
        public string Name  { get; set; }
        [Required]
        [MaxLength(255)]
        public string Phone  { get; set; }
        public string Email  { get; set; }
    }
}