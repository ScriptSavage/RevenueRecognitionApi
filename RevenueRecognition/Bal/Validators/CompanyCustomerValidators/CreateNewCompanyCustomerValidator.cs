using Bal.Dto;
using FluentValidation;

namespace Bal.Validators.CompanyCustomerValidators;

public class CreateNewCompanyCustomerValidator : AbstractValidator<CompanyCustomerDto.CompanyCustomer>
{
    public CreateNewCompanyCustomerValidator()
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


        RuleFor(e => e.CompanyName)
            .NotEmpty().WithMessage("CompanyName is required")
            .MaximumLength(250).WithMessage("CompanyName must not exceed 250 characters")
            .NotNull().WithMessage("CompanyName is required");
        
        RuleFor(e => e.Email)
            .EmailAddress().WithMessage("Email is required")
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(250).WithMessage("Email must not exceed 250 characters")
            .NotNull().WithMessage("Email is required");
        
        RuleFor(e => e.KRS)
            .NotEmpty().WithMessage("KRS is required")
            .MaximumLength(250).WithMessage("KRS must not exceed 250 characters")
            .NotNull().WithMessage("KRS is required");
    }
}