using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public interface IUserRepository
    {
        bool EmailExists(string email);
        void Add(User user);
    }
}