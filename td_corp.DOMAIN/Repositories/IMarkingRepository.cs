using System;
using System.Collections.Generic;
using td_corp.DOMAIN.Entities;

namespace td_corp.DOMAIN.Repositories
{
    public interface IMarkingRepository
    {
        void CreateMarking(Marking marca);
        void UpdateMarking(Marking entity);
        Marking GetById(Guid id);
        IEnumerable<Marking> GetAll();
        bool MarkingExists(string mark);
    }
}


