using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MovieStore.Core.Entities;
using MovieStore.Core.RepositoryInterfaces;
using MovieStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieStoreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(25).ToListAsync();
            // select top 25 from Movies order by Revenue desc;
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetHighestRatedMovies()
        {

            var movies = await _dbContext.Movies.OrderByDescending(m => m.Reviews.Average(r => r.Rating)).Take(25).ToListAsync();

            return (IEnumerable<Movie>)movies;
        }

        public async Task<IEnumerable<Movie>> GetMovieByGenreId(int id)
        {
            //var movies = await _dbContext.Movies.OrderByDescending(m => m.Reviews.Average(r => r.Rating)).Take(25).ToListAsync();
            var movies = await _dbContext.MovieGenres.Where(mg => mg.GenreId == id).Select(mg => mg.Movie).ToListAsync();

            return (IEnumerable<Movie>)movies;
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movies = await _dbContext.Movies
                .Include(m => m.MovieCasts)
                .ThenInclude(c => c.Cast)
                .Include(m => m.Reviews)
                .Where(m => m.Id == id)
                .FirstAsync();
            movies.Rating = movies.Reviews.Average(r => r.Rating);

            return movies;
        }

    }
}
