﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arenda.Models.ViewModel
{
    public class PremiseViewModel
    {
        public Premise Premise { get; set; }
        public IEnumerable<SelectListItem>? TypeOfFinishingSelectList { get; set; }
    }

    public class BuildingPremisesViewModel
    {
        public Building Building { get; set; }
        public IEnumerable<Premise> Premises { get; set; }
    }

    public class RentedPremiseViewModel
    {
        public IEnumerable<SelectListItem>? Premises { get; set; }
        public IEnumerable<SelectListItem>? RentPurposes { get; set; }
        public RentedPremise RentedPremise { get; set; }
        public int Index { get; set; }
    }
}
