using FluentValidation;
using StoryShelfApi.Models;

namespace StoryShelfApi.Impl.Validation
{
    public class GenreValidator : AbstractValidator<GenreRequest>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4).When(x=>x.Name.Trim() != string.Empty).MaximumLength(30);
        }
    }
}
