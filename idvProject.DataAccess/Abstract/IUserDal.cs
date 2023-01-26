using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>
    {
    }
}
