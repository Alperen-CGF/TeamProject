using idvProject.Business.Abstract;
using idvProject.Core.Utilities.Results;
using idvProject.DataAccess.Abstract;
using idvProject.DataAccess.EntityFramework;
using idvProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public IDataResult<List<Role>> GetAll()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetAll());
        }

        public IDataResult<Role> GetById(Guid id)
        {
            return new SuccessDataResult<Role>(_roleDal.Get(x => x.Id == id));
        }

        public IResult RoleAdd(Role role)
        {
            _roleDal.Insert(role);
            //_roleDal.AddMemory(role);
            return new SuccessResult("Role Başarılı Bir Şekilde Eklendi.");
        }

        public IResult RoleDelete(Role role)
        {
            _roleDal.Delete(role);
            return new SuccessResult("Role Başarılı Bir Şekilde Silindi.");
        }

        public IResult RoleUpdate(Role role)
        {
            _roleDal.Update(role);
            return new SuccessResult("Role Başarılı Bir Şekilde Güncellendi.");
        }
    }
}
