using System;

namespace td_corp.DOMAIN.Entities
{
    public class Model
    {
        public Model(string name, string description, Guid markingId, Marking marking)
        {
            Name = name;
            Description = description;
            MarkingId = markingId;
            Marking = marking;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid MarkingId { get; private set; }
        public virtual Marking Marking { get; private set; }

    }
}
