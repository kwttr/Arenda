using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Регистрационный номер")]
        public string RegistrationNumber { get; set; }

        public int PaymentFrequencyId { get; set; }
        [ForeignKey(nameof(PaymentFrequencyId))]
        public PaymentFrequency? PaymentFrequency { get; set; }

        public int ArendatorId { get; set; }
        [ForeignKey(nameof(ArendatorId))]
        public Arendator? Arendator { get; set; }

        public DateTime? StartOfContract { get; set; }
        public DateTime? EndOfContract { get; set; }

        [Display(Name = "Дополнительная информация")]
        public string? AdditionalInfo { get; set; }

        public List<RentedPremise> rentedPremises { get; set; }
    }

    public class PaymentFrequency
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
