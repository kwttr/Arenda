using System.ComponentModel.DataAnnotations;

namespace Arenda.Models
{
    public class PhysicalPerson : Arendator
    {
        public string PasportSerial { get; set; }
        public string PasportNumber { get; set; }
        public string IssuedByWhom { get; set; }
    }
}
