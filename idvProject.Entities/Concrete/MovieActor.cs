using idvProject.Core.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Entities.Concrete
{
    public class MovieActor : BaseEntity
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public Movie Movies { get; set; }
        public Actor Actors { get; set; }
    }
}
