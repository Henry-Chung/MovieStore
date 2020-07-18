using Microsoft.AspNetCore.Mvc;
using MovieStore.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MVC.Views.Shared.Components.Genres
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly GenreService _genreService;
        public GenresViewComponent(GenreService genreService)
        {
            _genreService = genreService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _genreService.GetAllGenres();
            return View();
        }
    }
}
