using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoryShelfApi.Context;
using StoryShelfApi.Impl.Cqrs;
using StoryShelfApi.Models;
using StoryShelfBase.ApiResponse;

namespace StoryShelfApi.Impl.Queries
{
    public class BookQueryHandler :
        IRequestHandler<GetAllBooksQuery, ApiResponse<List<BookResponse>>>,
        IRequestHandler<GetBookByIdQuery, ApiResponse<BookResponse>>
    {
        private readonly StoryShelfDbContext _context;
        private readonly IMapper _mapper;

        public BookQueryHandler(StoryShelfDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<BookResponse>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books.ToListAsync(cancellationToken);
            var mapped = _mapper.Map<List<BookResponse>>(books);

            return new ApiResponse<List<BookResponse>>(mapped);
        }

        public async Task<ApiResponse<BookResponse>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = _context.Books.FirstOrDefaultAsync(x=>x.Id == request.id);
            var mapped = _mapper.Map<BookResponse>(book);
            return new ApiResponse<BookResponse>(mapped);
        }
    }
}
