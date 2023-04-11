using FluentValidation;
using FluentValidation.Results;
using LaLiga.Domain.Models.Teams;
using System.Security.Cryptography.X509Certificates;

namespace LaLiga.Application.Services
{
    public class Validator: AbstractValidator<CreatedTeamsViewModel>
    {
        public Validator() 
        {
            RuleFor(x=> x.Name).NotEmpty().NotNull();
            RuleFor(x=> x.Color).NotEmpty().NotNull();
            RuleFor(x=> x.CreatedDate).NotEmpty().NotNull();
        }
        public bool Validation(CreatedTeamsViewModel createdTeamsViewModel)
        {
            string message = string.Empty;
            var teamsViewModel = new Validator();
            ValidationResult errors = teamsViewModel.Validate(createdTeamsViewModel);

            if (errors.IsValid == false)
            {
                message = errors.Errors[0].ToString();
                throw new Exception(message);
            }

            return true;
        }
    }
}
