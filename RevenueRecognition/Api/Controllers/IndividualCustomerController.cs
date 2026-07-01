using Bal.Dto;
using Bal.Services.IndividualCustomer;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/customers/individuals")]
public class IndividualCustomerController : ControllerBase
{
    private readonly IIndividualCustomerService _individualCustomerService;

    public IndividualCustomerController(IIndividualCustomerService individualCustomerService)
    {
        _individualCustomerService = individualCustomerService;
    }


    [HttpPost]
    public async Task<IActionResult> AddNewIndividualCustomer(
        [FromBody] IndividualCustomerDto.CreateNewIndividualCustomer request)
    {
        var result = await _individualCustomerService.AddCustomerAsync(request);

        return Ok(result);
    }


    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteCustomerAsync(long id)
    {
         await _individualCustomerService.DeleteCustomerAsync(id);
         return NoContent();
    }

    [HttpPatch("{id:long}")]
    public async Task<IActionResult> UpdateCustomerData(long id,
        [FromBody] IndividualCustomerDto.UpdateIndividualCustomer request)
    {
        await _individualCustomerService.UpdateCustomerAsync(id, request);
        return NoContent();
    }
    
}