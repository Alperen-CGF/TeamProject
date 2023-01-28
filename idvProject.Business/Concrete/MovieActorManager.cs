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
    public class MovieActorManager : IMovieActorService
    {
        private readonly IMovieActorDal _movieActorDal;
        public MovieActorManager(IMovieActorDal movieActorDal)
        {
            _movieActorDal = movieActorDal;
        }
        public IDataResult<List<MovieActor>> GetAll()
        {
            return new SuccessDataResult<List<MovieActor>>(_movieActorDal.GetAll());
        }

        public IDataResult<MovieActor> GetById(Guid id)
        {
            return new SuccessDataResult<MovieActor>(_movieActorDal.Get(x => x.Id == id));
        }

        public IResult MovieActorAdd(MovieActor movieActor)
        {
            _movieActorDal.Insert(movieActor);
            return new SuccessResult("MovieActor Başarılı Bir Şekilde Eklendi.");
        }

        public IResult MovieActorDelete(MovieActor movieActor)
        {
            _movieActorDal.Delete(movieActor);
            return new SuccessResult("MovieActor Başarılı Bir Şekilde Silindi.");
        }

        public IResult MovieActorUpdate(MovieActor movieActor)
        {
            _movieActorDal.Update(movieActor);
            return new SuccessResult("MovieActor Başarılı Bir Şekilde Güncellendi.");
        }
    }
}
