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
        List<MovieActor> GetAll();
        void MovieActorAdd(MovieActor movieActor);
        MovieActor GetById(int id);
        void MovieActorDelete(MovieActor movieActor);
        void MovieActorUpdate(MovieActor movieActor);
    }
}
