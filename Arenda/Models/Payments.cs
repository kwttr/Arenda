using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Payments
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Помещение")]
        public int RentedPremiseId { get; set; }
        [ForeignKey(nameof(RentedPremiseId))]
        public RentedPremise? RentedPremise { get; set; }

        [Display(Name = "Дата оплаты")]
        public DateTime? Date { get; set; }

        [Display(Name = "Сумма")]
        public int Amount { get; set; }
    }
}
