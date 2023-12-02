using Application.Customers.CreateCustomer;
using Application.Customers.DeleteCustomer;
using Application.Customers.ListCustomers;
using Application.Customers.LogInCustomer;
using Application.Customers.GetCustomerProfile;
using Application.Customers.ResetCustomerPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ISender _sender;

        public CustomerController(ILogger<CustomerController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> List()
        {
            try
            {
                var customers = await _sender.Send(new ListCustomersQuery());
                return Ok(customers);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCustomerCommand command)
        {
            try
            {
                await _sender.Send(command);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> Profile(Guid id)
        {
            try
            {
                var customers = await _sender.Send(new GetCustomerProfileQuery(id));
                return Ok(customers);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInCustomerCommand command)
        {
            try
            {
                var customers = await _sender.Send(command);

                if (customers is null)
                    return BadRequest("Invalid user password pair.");

                return Ok(customers);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _sender.Send(new DeleteRoomCommand(id));
                return Ok("User has been deleted successfully.");
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> ResetPassword(ResetPasswordCommand command)
        {
            try
            {
                await _sender.Send(command);
                return Ok("Your password has reset successfully.");
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}