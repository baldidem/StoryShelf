using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoryShelfApi.Context;
using StoryShelfApi.Domain;
using StoryShelfApi.Impl.Cqrs;
using StoryShelfApi.Models;
using StoryShelfBase.ApiResponse;

namespace StoryShelfApi.Impl.Queries
{
    public class GenreQueryHandler :
        IRequestHandler<GetAllGenresQuery, ApiResponse<List<GenreResponse>>>,
        IRequestHandler<GetGenreByIdQuery, ApiResponse<GenreResponse>>
    {
        private readonly StoryShelfDbContext _context;
        private readonly IMapper _mapper;

        public GenreQueryHandler(StoryShelfDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<GenreResponse>>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _context.Genres.Where(x=>x.IsActive).OrderBy(x=>x.Id).ToListAsync();
            var mapped = _mapper.Map<List<GenreResponse>>(genres);
            return new ApiResponse<List<GenreResponse>>(mapped);
        }

        public async Task<ApiResponse<GenreResponse>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.Where(x=>x.IsActive && x.Id==request.id).FirstOrDefaultAsync();
            if (genre == null)
            {
                return new ApiResponse<GenreResponse>("Genre bulunamadi");
            }
            var mapped = _mapper.Map<GenreResponse>(genre);
            return new ApiResponse<GenreResponse>(mapped);
        }
    }
}
