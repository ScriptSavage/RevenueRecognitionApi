using Bal.Dto;
using Bal.Services.CompanyCustomer;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/customers/companies")]
public class CompanyCustomerController : ControllerBase
{
    private readonly ICompanyCustomerService _companyCustomerService;

    public CompanyCustomerController(ICompanyCustomerService companyCustomerService)
    {
        _companyCustomerService = companyCustomerService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewCompanyClient([FromBody] CompanyCustomerDto.CompanyCustomer request)
    {
        await _companyCustomerService.AddCustomerAsync(request);
        return NoContent();
    }


    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateCompanyClient(long id,
        [FromBody] CompanyCustomerDto.UpdateCompanyCustomerDto request)
    {
       await _companyCustomerService.UpdateCustomerAsync(id,request);
       return NoContent();
    }


    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetClientDetails(long id)
    {
        var clientDetails = await _companyCustomerService.GetCustomerAsync(id);
        return Ok(clientDetails);
    }


}