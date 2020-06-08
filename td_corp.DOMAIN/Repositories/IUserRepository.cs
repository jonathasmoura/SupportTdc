using System;
using td_corp.DOMAIN.Entities;

namespace td_corp.DOMAIN.Repositories
{
    public interface IUserRepository
    {
        void Register(User user);
        User Authenticate(string nameUser, string password);
        User GetByEmail(string email);
    }
}


