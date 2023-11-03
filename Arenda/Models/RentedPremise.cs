using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class RentedPremise
    {
        [Key]
        public int Id { get; set; }

        public int PremiseId { get; set; }
        [ForeignKey(nameof(PremiseId))]
        public Premise? Premise { get; set; }

        public int RentPurposeId { get; set; }
        [ForeignKey(nameof(RentPurposeId))]
        public RentPurpose? RentPurpose { get; set; }

        public int ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public Contract? Contract { get; set; }

        public int RentCost { get; set; }
    }

    public class RentPurpose
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
