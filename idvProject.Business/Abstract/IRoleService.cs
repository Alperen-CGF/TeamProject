using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Abstract
{
    public interface IRoleService
    {
        List<Role> GetAll();
        void RoleAdd(Role role);
        Role GetById(int id);
        void RoleDelete(Role role);
        void RoleUpdate(Role role);
    }
}
