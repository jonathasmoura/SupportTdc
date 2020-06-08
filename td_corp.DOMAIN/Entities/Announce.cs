using System;

namespace td_corp.DOMAIN.Entities
{
    public class Announce
    {

        public string Nome { get; private set; }
        public DateTime FabricationYear { get; private set; }
        public decimal ValueAnnounce { get; private set; }
        public string Collor { get; private set; }
        public EFuelType FuelType { get; private set; }
        public Guid MarkingId { get; private set; }
        public Guid ModelId { get; private set; }
        public virtual Marking Marking { get; private set; }
        public virtual Model Model { get; private set; }
    }
}

