using idvProject.DataAccess.Abstract;
using idvProject.DataAccess.Concrete.Repositories;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.DataAccess.EntityFramework
{
    public class EfUserRoleDal:GenericRepository<UserRole>,IUserRoleDal
    {
    }
}
