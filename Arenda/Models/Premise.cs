using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Premise
    {
        [Key]
        public int Id { get; set; }

        public int TypeOfFinishingId { get; set; }
        [ForeignKey(nameof(TypeOfFinishingId))]
        public TypeOfFinishing? TypeOfFinishing { get; set; }

        public int BuildingId { get; set; }
        [ForeignKey(nameof(BuildingId))]
        public Building? Building { get; set; }

        public int PremiseNumber { get; set; }
        public double UsableArea { get; set; }
        public int Floor { get; set; }
        public bool NumberExist { get; set; }
    }

    public class TypeOfFinishing
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
