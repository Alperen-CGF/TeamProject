using idvProject.Core.Utilities.Results;
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
        IDataResult<List<Actor>> GetAll();
        IResult ActorAdd(Actor actor);
        IDataResult<Actor> GetById(Guid id);
        IResult ActorDelete(Actor actor);
        IResult ActorUpdate(Actor actor);
    }
}
