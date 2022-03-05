﻿using Microsoft.AspNetCore.Mvc;
using MovieProDemo.Services.Interfaces;
using System.Threading.Tasks;

namespace MovieProDemo.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IRemoteMovieService _tmdbMovieService;
        private readonly IDataMappingService _mappingService;


        public ActorsController(IRemoteMovieService tmdbMovieService, IDataMappingService mappingService)
        {
            _tmdbMovieService = tmdbMovieService;
            _mappingService = mappingService;
        }



        public async Task<IActionResult> Detail(int id)
        {
            var actor = await _tmdbMovieService.ActorDetailAsync(id);
            actor = _mappingService.MapActorDetail(actor);
            return View(actor);
        }
    }
}
