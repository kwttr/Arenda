using System.ComponentModel.DataAnnotations;

namespace Arenda.Models
{
    public class PhysicalPerson : Arendator
    {
        [Display(Name = "Серия паспорта")]
        public string PasportSerial { get; set; }
        [Display(Name = "Номер паспорта")]
        public string PasportNumber { get; set; }
        [Display(Name = "Кем выдан паспорт")]
        public string IssuedByWhom { get; set; }
    }
}
