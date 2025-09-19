using Application.Dtos;
using FluentValidation;

public class HomeDtoValidator : AbstractValidator<HomeDto>
{
    public HomeDtoValidator(bool isUpdate = false)
    {
        if (isUpdate)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Invalid user ID");
        }

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type required")
            .MaximumLength(100).WithMessage("Type shuould be less than 100 signs");

        RuleFor(x => x.Bio)
            .MaximumLength(1000).WithMessage("Bio should be less than 1000 signs")
            .When(x => !string.IsNullOrEmpty(x.Bio));

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0m).WithMessage("Price should be positive");

        RuleFor(x => x.OwnerNumber)
            .NotEmpty().WithMessage("OwnerNumber required.")
            .MaximumLength(50).WithMessage("OwnerNumber is too long");

        RuleFor(x => x.OwnerNumber)
            .Matches(@"^\+?[0-9\s\-()]{5,50}$")
            .WithMessage("OwnerNumber is in Invalid form (only numbers and +, (), -, space allowed).");

        RuleFor(x => x.NumberOfRooms)
            .GreaterThan(0).WithMessage("NumberOfRooms must be positive");

        RuleFor(x => x.ImageUrls)
            .NotNull().WithMessage("ImageUrls maydon null bo'lmasligi lozim.")
            .Must(list => list.Count <= 20).WithMessage("ImageUrls maksimal 20 ta rasm bo'lishi mumkin.")
            .When(x => x.ImageUrls != null);


        RuleForEach(x => x.ImageUrls)
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("ImageUrls ichida noto'g'ri url mavjud.");

        RuleFor(x => x.LocationId)
            .GreaterThan(0).WithMessage("LocationId musbat bo'lishi kerak.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId musbat bo'lishi kerak.");
    }
}