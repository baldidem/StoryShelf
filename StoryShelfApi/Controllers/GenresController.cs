using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoryShelfApi.Impl.Cqrs;
using StoryShelfApi.Models;
using StoryShelfBase.ApiResponse;

namespace StoryShelfApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<GenreResponse>>> GetAll()
        {
            var operation = new GetAllGenresQuery();
            var result = await _mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<GenreResponse>> GetById([FromRoute] int id)
        {
            var operation = new GetGenreByIdQuery(id);
            var result = await _mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<GenreResponse>> Post([FromBody] GenreRequest request)
        {
            var operation = new CreateGenreCommand(request);
            var result = await _mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] GenreRequest genre)
        {
            var operation = new UpdateGenreCommand(id, genre);
            var result = await _mediator.Send(operation);
            return result;
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteGenreCommand(id);
            var result = await _mediator.Send(operation);
            return result;
        }
    }
}
