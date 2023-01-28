using idvProject.Core.Utilities.Results;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Abstract
{
    public interface IMovieActorService
    {
        IDataResult<List<MovieActor>> GetAll();
        IResult MovieActorAdd(MovieActor movieActor);
        IDataResult<MovieActor> GetById(Guid id);
        IResult MovieActorDelete(MovieActor movieActor);
        IResult MovieActorUpdate(MovieActor movieActor);
    }
}
