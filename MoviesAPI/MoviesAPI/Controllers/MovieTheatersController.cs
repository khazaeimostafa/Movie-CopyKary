using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DTOs;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/movietheaters")]
    public class MovieTheatersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        private readonly IMapper mapper;

        public MovieTheatersController(
            ApplicationDbContext context,
            IMapper mapper
        )
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieTheaterDTO>>> Get()
        {
            var entities =
                await context.MovieTheaters.OrderBy(m => m.Name).ToListAsync();

            return mapper.Map<List<MovieTheaterDTO>>(entities);
        }

        [HttpGet("{int:id}")]
        public async Task<ActionResult<MovieTheaterDTO>> Get(int id)
        {
            var movieTheater =
                await context
                    .MovieTheaters
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (movieTheater == null)
            {
                return NotFound();
            }

            return mapper.Map<MovieTheaterDTO>(movieTheater);
        }

        [HttpPost]
        public async Task<ActionResult>
        Post(MovieTheaterCreationDTO movieTheaterCreationDTO)
        {
            var movieTheater =
                mapper.Map<MovieTheaterDTO>(movieTheaterCreationDTO);

            context.Add (movieTheater);

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{int:id}")]
        public async Task<ActionResult>
        Put(int id, MovieTheaterCreationDTO movieCreationDTO)
        {
            var movieTheater =
                await context
                    .MovieTheaters
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (movieTheater == null)
            {
                return NotFound();
            }

            movieTheater = mapper.Map(movieCreationDTO, movieTheater);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{int:id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var movieTheater =
                await context
                    .MovieTheaters
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (movieTheater == null)
            {
                return NotFound();
            }

            context.Remove (movieTheater);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
