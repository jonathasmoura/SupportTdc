using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using td_corp.DOMAIN.Entities;
using td_corp.DOMAIN.Repositories;
using td_corp.INFRA.DataContext;

namespace td_corp.INFRA.Repositories
{
    public class MarkingRepository : IMarkingRepository
    {
        private readonly CorpContext _context;
        public MarkingRepository(CorpContext context)
        {
            _context = context;
        }
        public void CreateMarking(Marking marca)
        {
            _context.Markings.Add(marca);
            _context.SaveChanges();
        }

        public IEnumerable<Marking> GetAll()
        {
            var all = _context.Markings
            .AsNoTracking()
            .Where(x => x.IsActive == true)
            .OrderBy(x => x.Name);

            return all;
        }

        public Marking GetById(Guid id)
        {
            var mark = _context.Markings
            .Include(x => x.Models)
            .FirstOrDefault(x => x.Id == id);
            return mark;
        }

        public bool MarkingExists(string mark)
        {
            var sql = _context.Markings.Any(x => x.Name == mark);
            return sql;
        }

        public void UpdateMarking(Marking entity)
        {
            _context.Entry<Marking>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
