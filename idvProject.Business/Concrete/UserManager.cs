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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(Guid id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == id));
        }

        public IResult UserAdd(User user)
        {
            _userDal.Insert(user);
            return new SuccessResult("User Başarılı Bir Şekilde Eklendi.");
        }

        public IResult UserDelete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("User Başarılı Bir Şekilde Silindi.");
        }

        public IResult UserUpdate(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("User Başarılı Bir Şekilde Güncellendi.");
        }
    }
}
