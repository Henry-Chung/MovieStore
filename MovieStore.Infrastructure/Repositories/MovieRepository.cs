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
            //await _dbContext.Reviews.Where(r => r.MovieId == id).AverageAsync(r => r.Rating);
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
                .Where(m => m.Id == id)
                .Include(m => m.MovieCasts)
                .ThenInclude(c => c.Cast)
                .Include(m => m.MovieGenres)
                .ThenInclude(m => m.Genre)
                .FirstAsync();

            _dbContext.Reviews.Where(r => r.MovieId == id).Load();
            _dbContext.Purchases.Where(p => p.MovieId == id).Load();
            _dbContext.Favorites.Where(p => p.MovieId == id).Load();
            movies.Rating = movies.Reviews.Average(r => r.Rating);

            return movies;
        }

        public async Task<IEnumerable<Movie>> GetMovieByUserId(int UserId)
        {

            var movies = await _dbContext.Movies
                .Include(p => p.Purchases)
                .Where(m => m.Purchases.Any(p=> p.UserId == UserId))
                .ToListAsync();
            return movies;
        }

        public async Task<Movie> CheckTheMovieIsFavorite(int userId, int movieId)
        {
            var movies = await _dbContext.Movies
                .Include(p => p.Favorites)
                .Where(m => m.Favorites.Any(p => p.UserId == userId && p.MovieId == movieId)).FirstAsync();
            return movies;
        }
    }
}
