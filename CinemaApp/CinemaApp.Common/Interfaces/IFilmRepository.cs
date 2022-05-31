using CinemaApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.Interfaces
{
    public interface IFilmRepository : IGenericRepository<Film>
    {
        IEnumerable<Film> Find(string criteria);
    }
}
