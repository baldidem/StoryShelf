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

        //[HttpGet]
        //public 
        [HttpPost]
        public async Task<ApiResponse<BookResponse>> Post([FromBody] BookRequest request)
        {
            var operation = new CreateBookCommand(request);
            var result = await _mediator.Send(operation);
            return result;
        }
    }
}
