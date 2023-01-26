using idvProject.Business.Abstract;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Concrete
{
    public class UserManager : IUserService
    {
        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UserAdd(User user)
        {
            throw new NotImplementedException();
        }

        public void UserDelete(User user)
        {
            throw new NotImplementedException();
        }

        public void UserRoleAdd(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public void UserRoleDelete(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public void UserRoleUpdate(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public void UserUpdate(User user)
        {
            throw new NotImplementedException();
        }

        List<UserRole> IUserService.GetAll()
        {
            throw new NotImplementedException();
        }

        UserRole IUserService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
