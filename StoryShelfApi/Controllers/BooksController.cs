using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoryShelfApi.Impl.Cqrs;
using StoryShelfApi.Models;
using StoryShelfBase.ApiResponse;

namespace StoryShelfApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<BookResponse>>> GetAll()
        {
            var operation = new GetAllBooksQuery();
            var result = await _mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<BookResponse>> GetById([FromRoute] int id)
        {
            var operation = new GetBookByIdQuery(id);
            var result = await _mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<BookResponse>> Post([FromBody] BookRequest request)
        {
            var operation = new CreateBookCommand(request);
            var result = await _mediator.Send(operation);
            return result;
        }

        [HttpPut]
        public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] BookRequest book)
        {
            var operation = new UpdateBookCommand(id, book);
            var result = await _mediator.Send(operation);
            return result;
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteBookCommand(id);
            var result = await _mediator.Send(operation);
            return result;
        }
    }
}
