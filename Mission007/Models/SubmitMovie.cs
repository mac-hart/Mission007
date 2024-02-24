using Mission007.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06.Models
{
    public class SubmitMovie
    {
        [Key]
        public int MovieID { get; set; }
        // Category

        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
        public Categories Category { get; set; }

        [Required(ErrorMessage = "Add a title, please.")]
        public string Title { get; set; }

        [Range(1888, 2024)]
        [Required(ErrorMessage = "Add a year, please.")]
        public int Year { get; set; }

        // Director
        public string? Director { get; set; }

        // Rating
        public string? Rating { get; set; }

        [Required(ErrorMessage = "Mark if it is edited, please.")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Mark if it is copied to Plex, please.")]
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }
    }
}
