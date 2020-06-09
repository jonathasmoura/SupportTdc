using System;
using td_corp.SHARED;

namespace td_corp.DOMAIN.Entities
{
    public class Model : Entity
    {
        public Model(string name, string description, Guid markingId)
        {
            Name = name;
            Description = description;
            MarkingId = markingId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid MarkingId { get; private set; }
        public virtual Marking Marking { get; private set; }

        public void Activate() => IsActive = true;
        public void Inactivate() => IsActive = false;

        public void UpdateDescription(string description)
        {
            Description = description;
        }

    }
}
