using Domain.Contracts.UseCases.AddCustomer;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddCustomer;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerController : ControllerBase
    {
        private readonly IAddCustomerUserCase _addCustomerUserCase;

        public AddCustomerController(IAddCustomerUserCase addCustomerUserCase)
        {
            _addCustomerUserCase = addCustomerUserCase;
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCostumerInput input)
        {
            var customer = new Domain.Entities.Customer(input.Name, input.Email, input.Document);
            _addCustomerUserCase.AddCustomer(customer);

            return Created("", customer);
        }
    }
}
