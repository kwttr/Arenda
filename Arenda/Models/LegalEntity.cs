using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class LegalEntity : Arendator
    {
        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public Bank? Bank { get; set; }
        
        public int StreetId { get; set; }
        [ForeignKey("StreetId")]
        public Street? Street { get; set; }

        public int BuildingNumber { get; set; }
        public string PaymentAccount { get; set; }
        public string INN { get; set; }
    }
}
