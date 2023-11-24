using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arenda.Models.ViewModel
{
    public class LegalEntityViewModel
    {
        public LegalEntity LegalEntity {get;set;}
        public IEnumerable<SelectListItem>? StreetSelectList { get;set;}
        public IEnumerable<SelectListItem>? BankSelectList { get;set;}
    }
}
