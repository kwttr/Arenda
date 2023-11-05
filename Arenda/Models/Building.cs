using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }

        public int CityAreaId { get; set; }
        [ForeignKey(nameof(CityAreaId))]
        public CityArea? CityArea { get; set; }

        public int? PremisesCount { get; set; }
        public string NumberOfBuilding { get; set; }
        public string PhoneNumber { get; set; }

        public int StreetId { get; set; }
        public Street? Street { get; set; }
    }

    public class CityArea
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
