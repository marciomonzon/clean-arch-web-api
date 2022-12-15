using Domain.Contracts.UseCases.AddCustomer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddCustomer;
using WebApi.Models.Error;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerController : ControllerBase
    {
        private readonly IAddCustomerUserCase _addCustomerUserCase;
        private readonly IValidator<AddCostumerInput> _addCustomerInputValidator;

        public AddCustomerController(IAddCustomerUserCase addCustomerUserCase,
                                     IValidator<AddCostumerInput> addCustomerInputValidator)
        {
            _addCustomerUserCase = addCustomerUserCase;
            _addCustomerInputValidator = addCustomerInputValidator;
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCostumerInput input)
        {
            var validationResult = _addCustomerInputValidator.Validate(input);

            if (!validationResult.IsValid) 
                return BadRequest(validationResult.Errors.ToCustomValidationFailure());

            var customer = new Domain.Entities.Customer(input.Name, input.Email, input.Document);
            _addCustomerUserCase.AddCustomer(customer);

            return Created("", customer);
        }
    }
}
