using FluentValidation;
using FluentValidationApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FluentValidationApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerApiController : ControllerBase
    {
        readonly IValidator<Customer> _validator;
        public CustomerApiController(IValidator<Customer> validator)
        {
            _validator = validator;
        }
        // GET: api/<CustomerApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var result = _validator.Validate(customer);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x =>
                {
                    return new { property = x.PropertyName, error = x.ErrorMessage };
                }));
            }
            return Ok("Başarılı");
        }

        // PUT api/<CustomerApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
