using System;
using System.Linq;
using td_corp.SHARED;
using System.Collections.Generic;

namespace td_corp.DOMAIN.Entities
{
    public class Marking : Entity
    {        
        private IList<Model> _models;
        public Marking(string name)
        {
            Name = name;
            _models = new List<Model>();
        }

        public string Name { get; private set; }
        public virtual IReadOnlyCollection<Model> Models { get { return _models.ToArray(); } }
    }
}
