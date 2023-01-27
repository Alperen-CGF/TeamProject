using idvProject.Business.Abstract;
using idvProject.DataAccess.Abstract;
using idvProject.DataAccess.EntityFramework;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public List<Role> GetAll()
        {
            return _roleDal.GetAll();
        }

        public Role GetById(Guid id)
        {
            return _roleDal.Get(x => x.Id == id);
        }

        public void RoleAdd(Role role)
        {
            _roleDal.Insert(role);
        }

        public void RoleDelete(Role role)
        {
            _roleDal.Delete(role);
        }

        public void RoleUpdate(Role role)
        {
            _roleDal.Update(role);
        }
    }
}
