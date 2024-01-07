using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Penalty
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Контракт")]
        public int ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public Contract? Contract { get; set; }

        [Display(Name = "Размер штрафа")]
        public int Amount { get; set; }

        public bool IsPaid { get; set; } = false;
    }
}
