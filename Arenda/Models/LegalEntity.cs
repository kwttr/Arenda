using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class LegalEntity : Arendator
    {
        [Display(Name = "Банк")]
        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public Bank? Bank { get; set; }
        
        [Display(Name = "Улица")]        
        public int StreetId { get; set; }
        [ForeignKey("StreetId")]
        public Street? Street { get; set; }

        [Display(Name = "Номер здания")]
        public int BuildingNumber { get; set; }
        [Display(Name = "Расчётный счет в банке")]
        public string PaymentAccount { get; set; }
        [Display(Name = "ИНН арендатора")]
        public string INN { get; set; }
    }
}
