using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class RentedPremise
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Помещение")]
        public int PremiseId { get; set; }
        [ForeignKey(nameof(PremiseId))]
        public Premise? Premise { get; set; }

        [Display(Name = "Цель аренды")]
        public int RentPurposeId { get; set; }
        [ForeignKey(nameof(RentPurposeId))]
        public RentPurpose? RentPurpose { get; set; }

        [Display(Name = "Контракт")]
        public int ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public Contract? Contract { get; set; }

        [Display(Name = "Размер арендной платы")]
        public int RentCost { get; set; }

        [Display(Name = "Срок аренды")]
        public string RentalPeriod { get; set; }
    }

    public class RentPurpose
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
