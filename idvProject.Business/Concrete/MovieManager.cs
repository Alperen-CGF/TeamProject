using idvProject.Business.Abstract;
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
        public List<Movie> GetAll()
        {
            return _movieDal.GetAll();
        }

        public Movie GetById(Guid id)
        {
            return _movieDal.Get(x => x.Id == id);
        }

        public List<Movie> GetListByCategoryId(Guid id)
        {
            return _movieDal.List(x => x.CategoryId == id);
        }

        public void MovieAdd(Movie movie)
        {
            _movieDal.Insert(movie);
        }

        public void MovieDelete(Movie movie)
        {
            _movieDal.Delete(movie);
        }

        public void MovieUpdate(Movie movie)
        {
            _movieDal.Update(movie);
        }
    }
}
