using MovieStore.Core.Entities;
using MovieStore.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Infrastructure.Services
{
    public class GenreService
    {
        private readonly IGenreRepository _genreRepository;
        // Constructor Injection, inject GenreRepository class instance
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _genreRepository.ListAllAsync();
        }
    }

}
