using System;
using System.Linq;
using td_corp.DOMAIN.Entities;
using td_corp.DOMAIN.Repositories;
using td_corp.INFRA.DataContext;

namespace td_corp.INFRA.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CorpContext _contextCorp;

        public UserRepository(CorpContext corpContext)
        {
            _contextCorp = corpContext;
        }
        public void Register(User user)
        {
            _contextCorp.Users.Add(user);
        }

        public User Authenticate(string nameUser, string password)
        {
            return _contextCorp.Users
            .Where(x => x.Name == nameUser && x.Password == password)
            .FirstOrDefault();

        }

        public User GetByEmail(string email)
        {
            var userByEmail = _contextCorp.Users
            .Where(x => x.Email == email)
            .FirstOrDefault();

            return userByEmail;
        }
    }
}
