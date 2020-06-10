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
        public void Activate() => IsActive = true;
        public void Inactivate() => IsActive = false;
        public ICollection<Model> Models { get; set; }



        public void UpdateName(string name)
        {
            Name = name;
        }

    }
}
