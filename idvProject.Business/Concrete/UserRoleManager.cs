using idvProject.Business.Abstract;
using idvProject.Core.Utilities.Results;
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
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;
        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }
        public IDataResult<List<UserRole>> GetAll()
        {
            return new SuccessDataResult<List<UserRole>>(_userRoleDal.GetAll());
        }

        public IDataResult<UserRole> GetById(Guid id)
        {
            return new SuccessDataResult<UserRole>(_userRoleDal.Get(x=>x.Id == id));
        }

        public IResult UserRoleAdd(UserRole userRole)
        {
            _userRoleDal.Insert(userRole);
            return new SuccessResult("UserRole Başarılı Bir Şekilde Eklendi.");
        }

        public IResult UserRoleDelete(UserRole userRole)
        {
            _userRoleDal.Delete(userRole);
            return new SuccessResult("UserRole Başarılı Bir Şekilde Silindi.");
        }

        public IResult UserRoleUpdate(UserRole userRole)
        {
            _userRoleDal.Update(userRole);
            return new SuccessResult("UserRole Başarılı Bir Şekilde Güncellendi.");
        }
    }
}
