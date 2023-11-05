using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arenda.Models.ViewModel
{
    public class BuildingViewModel
    {
        public Building Building { get; set; }
        public IEnumerable<SelectListItem>? CityAreaSelectList { get; set; }
        public IEnumerable<SelectListItem>? StreetSelectList { get; set; }
    }
}
