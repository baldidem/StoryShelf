using AutoMapper;
using MediatR;
using StoryShelfApi.Context;
using StoryShelfApi.Domain;
using StoryShelfApi.Impl.Cqrs;
using StoryShelfApi.Models;
using StoryShelfBase.ApiResponse;

namespace StoryShelfApi.Impl.Commands
{
    public class BookCommandHandler :
        IRequestHandler<CreateBookCommand, ApiResponse<BookResponse>>,
        IRequestHandler<UpdateBookCommand, ApiResponse>,
        IRequestHandler<DeleteBookCommand, ApiResponse>
    {
        private readonly StoryShelfDbContext _context;
        private readonly IMapper _mapper;

        public BookCommandHandler(StoryShelfDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<BookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.book);
            await _context.Books.AddAsync(book,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            var mapped = _mapper.Map<BookResponse>(book);
            return new ApiResponse<BookResponse>(mapped);
        }

        public async Task<ApiResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == request.id);
            if (book == null)
            {
                return new ApiResponse("Kitap bulunamadi!");
            }
            book.PublishDate = request.book.PublishDate;
            book.Title = request.book.Title;
            book.GenreId = request.book.GenreId;
            book.PageCount = request.book.PageCount;
            await _context.SaveChangesAsync();
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == request.id);
            if (book == null)
            {
                return new ApiResponse("Kitap bulunamadi!");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return new ApiResponse();
        }
    }
}
