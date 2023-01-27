using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        void UserAdd(User user);
        User GetById(Guid id);
        void UserDelete(User user);
        void UserUpdate(User user);
    }
}
