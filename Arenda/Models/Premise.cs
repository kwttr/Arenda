using Arenda.Models.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arenda.Models
{
    public class Premise
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Вид отделки")]
        public int TypeOfFinishingId { get; set; }
        [ForeignKey(nameof(TypeOfFinishingId))]
        public TypeOfFinishing? TypeOfFinishing { get; set; }

        [Display(Name = "Здание")]
        public int BuildingId { get; set; }
        [ForeignKey(nameof(BuildingId))]
        public Building? Building { get; set; }

        [Display(Name = "Номер помещения")]
        public int PremiseNumber { get; set; }
        [BindProperty(BinderType = typeof(CustomDoubleModelBinder))]
        [Display(Name = "Полезная площадь")]
        public double UsableArea { get; set; }
        [Display(Name = "Этаж")]
        public int Floor { get; set; }
        [Display(Name = "Телефон (есть/нет)")]
        public bool NumberExist { get; set; }
    }

    public class TypeOfFinishing
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
