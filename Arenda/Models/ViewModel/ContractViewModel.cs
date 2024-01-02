using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arenda.Models.ViewModel
{
    public class ContractViewModel
    {
        public Contract Contract { get; set; }
        public IEnumerable<SelectListItem>? PaymentFrequencySelectList { get; set; }
        public IEnumerable<SelectListItem>? ArendatorSelectList { get; set; }
        public List<RentedPremise> Premises { get; set; } = new List<RentedPremise>();
    }

    public class ContractEditViewModel
    {
        public Contract Contract { get; set; }
        public IEnumerable<SelectListItem>? PaymentFrequencySelectList { get; set; }
        public IEnumerable<SelectListItem>? ArendatorSelectList { get; set; }
        public List<RentedPremiseViewModel> rentedPremiseViewModels { get; set; } = new();
        public List<RentedPremise> Premises { get; set; } = new List<RentedPremise>();
    }
}
