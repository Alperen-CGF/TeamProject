using idvProject.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Core.Concrete
{
    public class BaseEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool Status { get; set; }
    }
}
