using FluentValidation;
using StoryShelfApi.Models;

namespace StoryShelfApi.Impl.Validation
{
    public class BookValidator : AbstractValidator<BookRequest>
    {
        public BookValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
            RuleFor(x => x.PageCount).GreaterThan(0);
            RuleFor(x => x.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(x => x.Title).MinimumLength(10);
        }
    }
}
