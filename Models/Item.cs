using System.ComponentModel.DataAnnotations;

namespace wow.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}