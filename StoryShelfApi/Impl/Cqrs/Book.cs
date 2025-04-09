using MediatR;
using StoryShelfApi.Models;
using StoryShelfBase.ApiResponse;

namespace StoryShelfApi.Impl.Cqrs
{
    public record GetAllBooksQuery : IRequest<ApiResponse<List<BookResponse>>>;
    public record GetBookByIdQuery(int id) : IRequest<ApiResponse<BookResponse>>;
    public record CreateBookCommand(BookRequest book) : IRequest<ApiResponse<BookResponse>>;
    public record UpdateBookCommand(int id, BookRequest book) : IRequest<ApiResponse>;
    public record DeleteBookCommand(int id) : IRequest<ApiResponse>;
}
