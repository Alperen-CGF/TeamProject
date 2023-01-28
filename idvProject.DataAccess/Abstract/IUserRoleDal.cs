using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.DataAccess.Abstract
{
    public interface IUserRoleDal : IRepository<UserRole>
    {
        List<UserRole> GetByUserId(Expression<Func<UserRole,bool>> filter=null);
    }
}
