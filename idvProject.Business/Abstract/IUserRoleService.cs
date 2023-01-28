using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Abstract
{
    public interface IUserRoleService
    {
        List<UserRole> GetAll();
        void UserRoleAdd(UserRole userRole);
        UserRole GetById(Guid id);
        List<UserRole> GetByUserId(Guid userId);
        void UserRoleDelete(UserRole userRole);
        void UserRoleUpdate(UserRole userRole);
    }
}
