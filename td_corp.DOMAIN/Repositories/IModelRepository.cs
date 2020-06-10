using System;
using td_corp.DOMAIN.Entities;
using System.Collections.Generic;

namespace td_corp.DOMAIN.Repositories
{
    public interface IModelRepository
    {
        bool ExistsModel(string modelo, string descricao);
        void CreateModel(Model entity);
        void UpdateModel(Model entity);
        IEnumerable<Model> GetAll();
        Model GetById(Guid id);
    }
}


