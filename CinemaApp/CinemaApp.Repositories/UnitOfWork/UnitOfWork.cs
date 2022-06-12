using CinemaApp.Common.Interfaces;
using CinemaApp.Repositories.Context;
using CinemaApp.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CinemaContext _context;
        public ICinemaHallRepository CinemaHallRepository { get; private set; }
        public IFilmRepository FilmRepository { get; private set; }
        public IProjectionRepository ProjectionRepository { get; private set; }
        public ITicketRepository TicketRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IFilmGenreRepository FilmGenreRepository { get; set; }
        public UnitOfWork(CinemaContext context)
        {
            _context = context;
            CinemaHallRepository = new CinemaHallRepository(_context);
            FilmRepository = new FilmRepository(_context);
            ProjectionRepository = new ProjectionRepository(_context);
            TicketRepository = new TicketRepository(_context);
            UserRepository = new UserRepository(_context);
            FilmGenreRepository = new FilmGenreRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
