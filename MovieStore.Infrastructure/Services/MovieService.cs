using MovieStore.Core.Entities;
using MovieStore.Core.RepositoryInterfaces;
using MovieStore.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        // Constructor Injection, inject MovieRepository class instance
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetTop25HighestRevenueMovies()
        {
            //int x = 0;
            //int y = 5;
            //int z = y / x;
            return await _movieRepository.GetHighestRevenueMovies();
        }

        public async Task<IEnumerable<Movie>> GetTop25RatedMovies()
        {
            return await _movieRepository.GetHighestRatedMovies();
        }

        public async Task<Movie> GetMovieById(int id)
        {
           return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            return await _movieRepository.AddAsync(movie);
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            return await _movieRepository.UpdateAsync(movie);
        }


        public async Task<int> GetMoviesCount(string title = "")
        {
            return await _movieRepository.GetCountAsync(gmc => gmc.Title == title);
        }

        public async Task<IEnumerable<Movie>> GetMovieByGenreId(int id)
        {
            return await _movieRepository.GetMovieByGenreId(id);
        }
    }

}
