using System;
using Flunt.Notifications;

namespace td_corp.SHARED
{
    public abstract class Entity : Notifiable, IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            IsActive = true;
            Created = DateTime.Now;
            ActivationDate =  DateTime.Now;
        }

        public Guid Id { get; private set; }
        public bool IsActive { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? InactivationDate { get; set; }
        public DateTime Created { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
