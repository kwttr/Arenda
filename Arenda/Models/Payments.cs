using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Payments
    {
        [Key]
        public int Id { get; set; }
        
        public int RentedPremiseId { get; set; }
        [ForeignKey(nameof(RentedPremiseId))]
        public RentedPremise? RentedPremise { get; set; }

        public DateTime? Date { get; set; }

        public int Amount { get; set; }
    }
}
