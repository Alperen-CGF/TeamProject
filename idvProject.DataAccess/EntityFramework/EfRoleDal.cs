using idvProject.DataAccess.Abstract;
using idvProject.DataAccess.Concrete;
using idvProject.DataAccess.Concrete.Repositories;
using idvProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.DataAccess.EntityFramework
{
    public class EfRoleDal : GenericRepository<Role>, IRoleDal
    {
        DataBaseContext Db=new DataBaseContext();
        public async void AddMemory(Role role)
        {
            Db.Roles.AddAsync(role);
            Db.SaveChanges();
            //Memory Liste Kontrolü
            var Roles = Db.Roles.ToListAsync();
        }   
    }
}
