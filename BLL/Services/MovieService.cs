using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Repository;

namespace BLL.Services
{
    public class MovieService
    {
        private readonly MovieRepository _movieRepository;
        public MovieService(MovieRepository repository)
        {
            _movieRepository = repository;
        }
    }
}
