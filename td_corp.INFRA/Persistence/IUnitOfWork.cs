using System;

namespace td_corp.INFRA.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
