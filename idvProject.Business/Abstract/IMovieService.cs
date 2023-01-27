﻿using idvProject.Entities.Concrete;
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
        List<Movie> GetAll();
        List<Movie> GetListByCategoryId(Guid id);
        void MovieAdd(Movie movie);
        Movie GetById(Guid id);
        void MovieDelete(Movie movie);
        void MovieUpdate(Movie movie);
    }
}
