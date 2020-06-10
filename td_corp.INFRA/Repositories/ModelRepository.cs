using System;
using System.Linq;
using td_corp.DOMAIN.Entities;
using td_corp.INFRA.DataContext;
using System.Collections.Generic;
using td_corp.DOMAIN.Repositories;
using Microsoft.EntityFrameworkCore;

namespace td_corp.INFRA.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly CorpContext _context;
        public ModelRepository(CorpContext context)
        {
            _context = context;
        }
        public void CreateModel(Model entity)
        {
            _context.Models.Add(entity);
            _context.SaveChanges();
        }

        public bool ExistsModel(string modelo, string descricao)
        {
            var mod = _context.Models.Any(x => x.Name == modelo || x.Description == descricao);
            return mod;
        }

        public IEnumerable<Model> GetAll()
        {
            var all = _context.Models.AsNoTracking()
            .Where(x => x.IsActive == true)
            .OrderBy(x => x.Name);

            return all;
        }

        public Model GetById(Guid id)
        {
            var mod = _context.Models.FirstOrDefault(x => x.Id == id);
            return mod;
        }

        public void UpdateModel(Model entity)
        {
            _context.Entry<Model>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
