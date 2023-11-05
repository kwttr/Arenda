using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Район города")]
        public int CityAreaId { get; set; }
        [ForeignKey(nameof(CityAreaId))]
        public CityArea? CityArea { get; set; }

        public int? PremisesCount { get; set; }
        [Display(Name = "Номер здания")]
        public string NumberOfBuilding { get; set; }
        [Display(Name = "Телефон коменданта")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Улица")]
        public int StreetId { get; set; }
        [ForeignKey(nameof(StreetId))]
        public Street? Street { get; set; }
    }

    public class CityArea
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
