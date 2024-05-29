using FluentValidation;
using job_candidates.DTOS;

namespace CandidateApi.Validators
{
    public class CandidateDtoValidator : AbstractValidator<CandidateDto>
    {
        public CandidateDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50).WithMessage("First Name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50).WithMessage("Last Name cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\d{10}$").WithMessage("Phone Number must be 10 digits.");

            RuleFor(x => x.LinkedInProfile)
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                .WithMessage("Invalid LinkedIn profile URL.")
                .When(x => !string.IsNullOrEmpty(x.LinkedInProfile));

            RuleFor(x => x.GitHubProfile)
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                .WithMessage("Invalid GitHub profile URL.")
                .When(x => !string.IsNullOrEmpty(x.GitHubProfile));

            RuleFor(x => x.Comment).NotEmpty()
                .WithMessage("Comment is required.")
                .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");
        }
    }
}
