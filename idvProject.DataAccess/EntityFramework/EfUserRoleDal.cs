using idvProject.DataAccess.Abstract;
using idvProject.DataAccess.Concrete;
using idvProject.DataAccess.Concrete.Repositories;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.DataAccess.EntityFramework
{
    public class EfUserRoleDal : GenericRepository<UserRole>, IUserRoleDal
    {
        public List<UserRole> GetByUserId(Expression<Func<UserRole,bool>> filter=null)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var result = from userRole in context.UserRoles
                             join user in context.Users
                             on userRole.UserId equals user.Id
                             join role in context.Roles
                             on userRole.RoleId equals role.Id
                             select new UserRole
                             {
                                 RoleId = role.Id,
                                 UserId = user.Id,
                                 Roles = role,
                                 Users = user
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
