using idvProject.Business.Abstract;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        public List<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetListByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public void MovieAdd(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void MovieDelete(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void MovieUpdate(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
