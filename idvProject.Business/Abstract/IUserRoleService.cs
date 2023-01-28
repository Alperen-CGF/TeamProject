using idvProject.Core.Utilities.Results;
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
        IDataResult<List<UserRole>> GetAll();
        IResult UserRoleAdd(UserRole userRole);
        IDataResult<UserRole> GetById(Guid id);
        IResult UserRoleDelete(UserRole userRole);
        IResult UserRoleUpdate(UserRole userRole);
    }
}
