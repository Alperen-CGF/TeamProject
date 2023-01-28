using idvProject.Core.Utilities.Results;
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
        IDataResult<List<Role>> GetAll();
        IResult RoleAdd(Role role);
        IDataResult<Role> GetById(Guid id);
        IResult RoleDelete(Role role);
        IResult RoleUpdate(Role role);
    }
}
