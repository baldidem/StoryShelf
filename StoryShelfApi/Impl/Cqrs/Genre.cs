using MediatR;
using StoryShelfApi.Models;
using StoryShelfBase.ApiResponse;

namespace StoryShelfApi.Impl.Cqrs
{
    public record GetAllGenresQuery : IRequest<ApiResponse<List<GenreResponse>>>;
    public record GetGenreByIdQuery(int id): IRequest<ApiResponse<GenreResponse>>;
    public record CreateGenreCommand(GenreRequest genre) : IRequest<ApiResponse<GenreResponse>>;
    public record UpdateGenreCommand(int id, GenreRequest genre) : IRequest<ApiResponse>;
    public record DeleteGenreCommand(int id) : IRequest<ApiResponse>;

}
