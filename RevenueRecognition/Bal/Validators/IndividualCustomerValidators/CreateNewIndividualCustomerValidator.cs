using Bal.Dto;
using FluentValidation;

namespace Bal.Validators.IndividualCustomerValidators;

public class CreateNewIndividualCustomerValidator : AbstractValidator<IndividualCustomerDto.CreateNewIndividualCustomer>
{
    public CreateNewIndividualCustomerValidator()
    {
        RuleFor(e=>e.City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(250).WithMessage("City must not exceed 250 characters")
            .NotNull().WithMessage("City is required");
        
        RuleFor(e=>e.Street)
            .NotEmpty().WithMessage("Street is required")
            .MaximumLength(250).WithMessage("Street must not exceed 250 characters")
            .NotNull().WithMessage("Street is required");
        
        RuleFor(e=>e.PostalCode)
            .NotEmpty().WithMessage("PostalCode is required")
            .MaximumLength(6).WithMessage("PostalCode must not exceed 6 characters")
            .NotNull().WithMessage("PostalCode is required");
        
        
        RuleFor(e=>e.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required")
            .MaximumLength(150).WithMessage("PhoneNumber must not exceed 150 characters")
            .NotNull().WithMessage("PhoneNumber is required");
        
        RuleFor(e=>e.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(150).WithMessage("Email must not exceed 250 characters")
            .NotNull().WithMessage("Email is required")
            .EmailAddress();

        RuleFor(e => e.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .MaximumLength(250).WithMessage("FirstName must not exceed 250 characters")
            .NotNull().WithMessage("FirstName is required");
        
        RuleFor(e => e.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .MaximumLength(250).WithMessage("LastName must not exceed 250 characters")
            .NotNull().WithMessage("LastName is required");


        RuleFor(e => e.Pesel)
            .NotEmpty().WithMessage("Pesel is required")
            .MaximumLength(11).WithMessage("Pesel must not exceed 11 characters")
            .NotNull().WithMessage("Pesel is required");
    }
}