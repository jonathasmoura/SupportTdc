using System;
using td_corp.INFRA.DataContext;

namespace td_corp.INFRA.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private CorpContext _corpContext;

        public UnitOfWork(CorpContext corpContext)
        {
            _corpContext = corpContext;
        }

        public void Commit()
        {
            _corpContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_corpContext != null)
                {
                    _corpContext.Dispose();
                    _corpContext = null;
                }
            }
        }
    }
}
