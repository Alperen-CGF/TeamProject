using idvProject.Business.Abstract;
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
    public class MovieActorManager : IMovieActorService
    {
        private readonly IMovieActorDal _movieActorDal;
        public MovieActorManager(IMovieActorDal movieActorDal)
        {
            _movieActorDal = movieActorDal;
        }
        public List<MovieActor> GetAll()
        {
            return _movieActorDal.GetAll();
        }

        public MovieActor GetById(Guid id)
        {
            return _movieActorDal.Get(x => x.Id == id);
        }

        public void MovieActorAdd(MovieActor movieActor)
        {
            _movieActorDal.Insert(movieActor);
        }

        public void MovieActorDelete(MovieActor movieActor)
        {
            _movieActorDal.Delete(movieActor);
        }

        public void MovieActorUpdate(MovieActor movieActor)
        {
            _movieActorDal.Update(movieActor);
        }
    }
}
