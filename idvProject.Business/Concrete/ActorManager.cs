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
    public class ActorManager : IActorService
    {
        private readonly IActorDal _actorDal;
        public ActorManager(IActorDal actorDal)
        {
            _actorDal = actorDal;
        }
        public void ActorAdd(Actor actor)
        {
            _actorDal.Insert(actor);
        }

        public void ActorDelete(Actor actor)
        {
            _actorDal.Delete(actor);
        }

        public void ActorUpdate(Actor actor)
        {
            _actorDal.Update(actor);
        }

        public List<Actor> GetAll()
        {
            return _actorDal.GetAll();
        }

        public Actor GetById(Guid id)
        {
            return _actorDal.Get(x => x.Id == id);
        }
    }
}
