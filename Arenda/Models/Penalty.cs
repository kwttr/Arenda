using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Penalty
    {
        [Key]
        public int Id { get; set; }

        public int ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public Contract? Contract { get; set; }
        
        public int Amount { get; set; }

        public bool IsPaid { get; set; } = false;
    }
}
