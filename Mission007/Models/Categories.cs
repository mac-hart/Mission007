using System.ComponentModel.DataAnnotations;

namespace Mission007.Models
{
    public class Categories
    {
        [Key]
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }

}
