using System.ComponentModel.DataAnnotations;

namespace Arenda.Models
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        public int StreetId { get; set; }
        public Street? Street { get; set; }

        public string Name { get; set; }
    }
}
