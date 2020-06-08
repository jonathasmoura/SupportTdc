using System;

namespace td_corp.DOMAIN.Entities
{
    public class User
    {
        public User(string name, string email, string password, bool isAdmin)
        {
            Name = name;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; } 
        public bool IsAdmin { get; private set; }

        public void AprovedAnnouce(string name)
        {
            Name = name;
            IsAdmin = true;
        }
    }
}
