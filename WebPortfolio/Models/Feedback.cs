using System.ComponentModel.DataAnnotations;

namespace WebPortfolio.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
