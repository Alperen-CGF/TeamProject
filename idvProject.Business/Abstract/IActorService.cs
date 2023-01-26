using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Abstract
{
    public interface IActorService
    {
        List<Actor> GetAll();
        void ActorAdd(Actor actor);
        Actor GetById(int id);
        void ActorDelete(Actor actor);
        void ActorUpdate(Actor actor);
    }
}
