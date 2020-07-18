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
        //Task<Movie> Get(int id);
        //Task<Movie> Create(Movie movie);
        //Task<Movie> Update(Movie movie);
    }
}
