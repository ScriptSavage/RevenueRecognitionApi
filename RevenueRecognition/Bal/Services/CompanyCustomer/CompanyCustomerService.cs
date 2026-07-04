using Bal.Dto;
using Bal.Exceptions;
using Dal.Repositories.Customers;
using Dal.Repositories.UnitWork;
using FluentValidation;

namespace Bal.Services.CompanyCustomer;

public class CompanyCustomerService :  ICompanyCustomerService
{
    private readonly ICompanyCustomerRepository _companyCustomerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CompanyCustomerDto.CompanyCustomer> _companyCustomerValidator;

    public CompanyCustomerService(ICompanyCustomerRepository companyCustomerRepository, 
        IUnitOfWork unitOfWork,
        IValidator<CompanyCustomerDto.CompanyCustomer> companyCustomerValidator)
    {
        _companyCustomerRepository = companyCustomerRepository;
        _unitOfWork = unitOfWork;
        _companyCustomerValidator = companyCustomerValidator;
    }


    public async Task AddCustomerAsync(CompanyCustomerDto.CompanyCustomer request)
    {

        var validationResult = await _companyCustomerValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var newCompanyCustomer = new Dal.Entities.CompanyCustomer()
        {
            Krs = request.KRS,
            CompanyName = request.CompanyName,
            Email = request.Email,
            City = request.City,
            PhoneNumber = request.PhoneNumber,
            PostalCode = request.PostalCode,
            Street = request.Street
        };
        
        
        var doesCompanyKrsExist = await _companyCustomerRepository
            .DoesCompanyKrsExist(newCompanyCustomer.Krs);

        if (doesCompanyKrsExist)
        {
            throw new AlreadyExistsException("Invalid Krs");
        }

        await _companyCustomerRepository.AddAsync(newCompanyCustomer);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(long id)
    {
        var client = await _companyCustomerRepository.GetByIdAsync(id);
        _companyCustomerRepository.Delete(client);
    }

    public async Task UpdateCustomerAsync(long id, CompanyCustomerDto.UpdateCompanyCustomerDto request)
    {
        var client = await _companyCustomerRepository.GetByIdAsync(id);
        
        if (!string.IsNullOrWhiteSpace(request.City)) client.City = request.City;
        if (!string.IsNullOrWhiteSpace(request.Street)) client.Street = request.Street;
        if (!string.IsNullOrWhiteSpace(request.PostalCode)) client.PostalCode = request.PostalCode;
        if (!string.IsNullOrWhiteSpace(request.PhoneNumber)) client.PhoneNumber = request.PhoneNumber;
        if (!string.IsNullOrWhiteSpace(request.Email)) client.Email = request.Email;
        if (!string.IsNullOrWhiteSpace(request.CompanyName)) client.CompanyName = request.CompanyName;
        
        _companyCustomerRepository.Update(client);
        await _unitOfWork.SaveChangesAsync();
    }
    

    public async Task<CompanyCustomerDto.CompanyCustomer> GetCustomerAsync(long id)
    {
        var client = await _companyCustomerRepository.GetByIdAsync(id);

        var result = new CompanyCustomerDto.CompanyCustomer(client.City,
            client.Street,
            client.PostalCode,
            client.PhoneNumber,
            client.Email,
            client.Krs,
            client.CompanyName);
        
        return result;
    }
}