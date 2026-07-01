using Bal.Dto;
using Bal.Exceptions;
using Dal.Entities;
using Dal.Repositories.Customers;
using Dal.Repositories.UnitWork;
using FluentValidation;

namespace Bal.Services.IndividualCustomer;

public class IndividualCustomerService : IIndividualCustomerService
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<IndividualCustomerDto.CreateNewIndividualCustomer> _createNewIndividualCustomerValidator;

    public IndividualCustomerService(IIndividualCustomerRepository individualCustomerRepository, 
        IUnitOfWork unitOfWork, 
        IValidator<IndividualCustomerDto.CreateNewIndividualCustomer> createNewIndividualCustomerValidator)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _unitOfWork = unitOfWork;
        _createNewIndividualCustomerValidator = createNewIndividualCustomerValidator;
    }

    public async Task<IndividualCustomerDto.Response> AddCustomerAsync(IndividualCustomerDto.CreateNewIndividualCustomer request)
    {
        
       var validationResult = await _createNewIndividualCustomerValidator.ValidateAsync(request);

       if (!validationResult.IsValid)
       {
           throw new ValidationException(validationResult.Errors);
       }

       var doesCustomerExist = await _individualCustomerRepository.DoesCustomerExist(request.Pesel);

       if (doesCustomerExist)
       {
           throw new AlreadyExistsException("Customer Already Exists");
       }

       var newCustomer = new Dal.Entities.IndividualCustomer(request.Email, 
            request.PhoneNumber,
            request.City,
            request.Street,
            request.PostalCode,
            request.FirstName,
            request.LastName,
            request.Pesel);
        
        
        await _individualCustomerRepository.AddAsync(newCustomer);

        await _unitOfWork.SaveChangesAsync();
        
        return new IndividualCustomerDto.Response(newCustomer.Email, newCustomer.FirstName, newCustomer.LastName);
    }

    public async Task DeleteCustomerAsync(long id)
    {
        var customer = await _individualCustomerRepository.GetByIdAsync(id);

        if (customer == null)
        {
            throw new DoesNotExistsException("Customer does not exist");
        }

        
        _individualCustomerRepository.Delete(customer);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync(long id, IndividualCustomerDto.UpdateIndividualCustomer request)
    {
        var customer = await _individualCustomerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            throw new DoesNotExistsException("Customer does not exist");
        }

        var transaction = await _unitOfWork.BeginTransactionAsync();

        try
        {
            if(!string.IsNullOrWhiteSpace(request.Email)) customer.Email = request.Email;
            if(!string.IsNullOrWhiteSpace(request.PhoneNumber)) customer.PhoneNumber = request.PhoneNumber;
            if(!string.IsNullOrWhiteSpace(request.City)) customer.City = request.City;
            if(!string.IsNullOrWhiteSpace(request.Street)) customer.Street = request.Street;
            if(!string.IsNullOrWhiteSpace(request.PostalCode)) customer.PostalCode = request.PostalCode;
            if(!string.IsNullOrWhiteSpace(request.FirstName)) customer.FirstName = request.FirstName;
            if(!string.IsNullOrWhiteSpace(request.LastName)) customer.LastName = request.LastName;
            await transaction.CommitAsync();
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception e)
        {
           await transaction.RollbackAsync();
           Console.WriteLine(e.Message);
        }
        
    }
}