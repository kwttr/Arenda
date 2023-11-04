namespace Arenda.Models.ViewModel
{
    public class ArendatorViewModel
    {
        public IEnumerable<LegalEntity> LegalEntities { get; set; }
        public IEnumerable<PhysicalPerson> PhysicalPersons { get; set; }
    }
}
