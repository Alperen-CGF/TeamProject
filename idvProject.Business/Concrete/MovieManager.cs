using idvProject.Business.Abstract;
using idvProject.Core.Utilities.Results;
using idvProject.DataAccess.Abstract;
using idvProject.DataAccess.EntityFramework;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDal _movieDal;
        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }
        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll());
        }

        public IDataResult<Movie> GetById(Guid id)
        {
            return new SuccessDataResult<Movie>(_movieDal.Get(x => x.Id == id));
        }

        public IDataResult<List<Movie>> GetListByCategoryId(Guid id)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.List(x => x.CategoryId == id));
        }

        public IResult MovieAdd(Movie movie)
        {
            _movieDal.Insert(movie);
            return new SuccessResult("Movie Başarılı Bir Şekilde Eklendi.");
        }

        public IResult MovieDelete(Movie movie)
        {
            _movieDal.Delete(movie);
            return new SuccessResult("Movie Başarılı Bir Şekilde Silindi.");
        }

        public IResult MovieUpdate(Movie movie)
        {
            _movieDal.Update(movie);
            return new SuccessResult("Movie Başarılı Bir Şekilde Güncellendi.");
        }
    }
}
