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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
            return new SuccessResult("Category Başarılı Bir Şekilde Eklendi.");
        }

        public IResult CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult("Category Başarılı Bir Şekilde Silindi.");
        }

        public IResult CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult("Category Başarılı Bir Şekilde Güncellendi.");
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(Guid id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(x => x.Id == id));
        }
    }
}
