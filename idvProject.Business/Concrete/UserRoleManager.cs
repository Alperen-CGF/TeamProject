using idvProject.Business.Abstract;
using idvProject.DataAccess.Abstract;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;
        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }
        public List<UserRole> GetAll()
        {
            return _userRoleDal.GetAll();
        }

        public UserRole GetById(Guid id)
        {
            return _userRoleDal.Get(x => x.Id == id);
        }

        public List<UserRole> GetByUserId(Guid userId)
        {
            return _userRoleDal.GetByUserId(x => x.UserId == userId);
        }

        public void UserRoleAdd(UserRole userRole)
        {
            _userRoleDal.Insert(userRole);
        }

        public void UserRoleDelete(UserRole userRole)
        {
            _userRoleDal.Delete(userRole);
        }

        public void UserRoleUpdate(UserRole userRole)
        {
            _userRoleDal.Update(userRole);
        }
    }
}
