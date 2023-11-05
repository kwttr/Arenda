using System.ComponentModel.DataAnnotations;

namespace Arenda.Models
{
    public class Street
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название улицы")]
        public string Name { get; set; }
    }
}
