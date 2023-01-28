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
    public class ActorManager : IActorService
    {
        private readonly IActorDal _actorDal;
        public ActorManager(IActorDal actorDal)
        {
            _actorDal = actorDal;
        }
        public IResult ActorAdd(Actor actor)
        {
            _actorDal.Insert(actor);
            return new SuccessResult("Actor Başarılı Bir Şekilde Eklendi.");
        }

        public IResult ActorDelete(Actor actor)
        {
            _actorDal.Delete(actor);
            return new SuccessResult("Actor Başarılı Bir Şekilde Silindi.");
        }

        public IResult ActorUpdate(Actor actor)
        {
            _actorDal.Update(actor);
            return new SuccessResult("Actor Başarılı Bir Şekilde Güncellendi.");
        }

        public IDataResult<List<Actor>> GetAll()
        {
            return new SuccessDataResult<List<Actor>>(_actorDal.GetAll());
        }

        public IDataResult<Actor> GetById(Guid id)
        {
            return new SuccessDataResult<Actor>(_actorDal.Get(x => x.Id == id));
        }
    }
}
