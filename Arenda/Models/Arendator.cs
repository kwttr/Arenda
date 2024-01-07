
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Arendator
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string LastName { get; set; }
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
    }
}
