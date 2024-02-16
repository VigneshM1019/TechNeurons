using System.ComponentModel.DataAnnotations;

namespace TechNeuronsProj.Models.Domain
{
    public class Task
    {

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public  string Name { get; set; }
        [Required]
        [StringLength(500)]
        public  string Description { get; set; }
    }
}
