using idvProject.Core.Utilities.Results;
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
        IDataResult<List<User>> GetAll();
        IResult UserAdd(User user);
        IDataResult<User> GetById(Guid id);
        IResult UserDelete(User user);
        IResult UserUpdate(User user);
    }
}
