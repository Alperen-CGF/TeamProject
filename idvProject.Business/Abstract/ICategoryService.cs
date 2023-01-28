using idvProject.Core.Utilities.Results;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IResult CategoryAdd(Category category);
        IDataResult<Category> GetById(Guid id);
        IResult CategoryDelete(Category category);
        IResult CategoryUpdate(Category category);
    }
}
