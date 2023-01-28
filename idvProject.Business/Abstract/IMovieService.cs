using idvProject.Core.Utilities.Results;
using idvProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<List<Movie>> GetAll();
        IDataResult<List<Movie>> GetListByCategoryId(Guid id);
        IResult MovieAdd(Movie movie);
        IDataResult<Movie> GetById(Guid id);
        IResult MovieDelete(Movie movie);
        IResult MovieUpdate(Movie movie);
    }
}
