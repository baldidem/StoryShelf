using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoryShelfApi.Context;
using StoryShelfApi.Domain;
using StoryShelfApi.Impl.Cqrs;
using StoryShelfApi.Models;
using StoryShelfBase.ApiResponse;

namespace StoryShelfApi.Impl.Commands
{
    public class GenreCommandHandler :
        IRequestHandler<CreateGenreCommand, ApiResponse<GenreResponse>>,
        IRequestHandler<UpdateGenreCommand, ApiResponse>,
        IRequestHandler<DeleteGenreCommand, ApiResponse>
    {
        private readonly StoryShelfDbContext _context;
        private readonly IMapper _mapper;

        public GenreCommandHandler(StoryShelfDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<GenreResponse>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreExist = await _context.Genres.SingleOrDefaultAsync(x => x.Name == request.genre.Name);
            if (genreExist is not null)
            {
                return new ApiResponse<GenreResponse>("Kitap turu zaten mevcut");
            }
            var genre = _mapper.Map<Genre>(request.genre);
            await _context.AddAsync(genre);
            await _context.SaveChangesAsync();
            var mapped = _mapper.Map<GenreResponse>(genre);
            return new ApiResponse<GenreResponse>(mapped);
        }

        public async Task<ApiResponse> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.Where(x => x.Id == request.id).FirstOrDefaultAsync();
            if (genre == null)
            {
                return new ApiResponse("Kitap turu bulunamadi!");
            }
            if (_context.Genres.Any(x => x.Name.ToLower() == request.genre.Name.ToLower() && x.Id != request.id))
            {
                return new ApiResponse("Ayni isimde kitap turu mevcut!");

            }
            genre.IsActive = request.genre.IsActive;
            genre.Name = request.genre.Name.Trim() == default ? genre.Name : request.genre.Name;
            await _context.SaveChangesAsync();
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.Where(x => x.Id == request.id).FirstOrDefaultAsync();
            if (genre == null)
            {
                return new ApiResponse("Kitap turu silinemez");
            }
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return new ApiResponse();
        }
    }
}
