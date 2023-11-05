using System.ComponentModel.DataAnnotations;

namespace Arenda.Models
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Улица")]
        public int StreetId { get; set; }
        public Street? Street { get; set; }

        [Display(Name = "Название банка")]
        public string Name { get; set; }
    }
}
