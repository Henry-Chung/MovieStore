using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.RepositoryInterfaces
{
    public interface IMovieRepository: IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetHighestRevenueMovies();
        Task<IEnumerable<Movie>> GetHighestRatedMovies();
        Task<IEnumerable<Movie>> GetMovieByGenreId(int id);
        Task<IEnumerable<Movie>> GetMovieByUserId(int UserId);

        Task<Movie> CheckTheMovieIsFavorite(int userId, int movieId);
    }
}
