using Application.Repostories.EmployeeRepository;
using Application.ViewModels;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Persistance.Context;

namespace OnionArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRead _employeeRead;
        private readonly IEmployeeWrite _employeeWrite;
        public EmployeeController(IEmployeeRead employeeRead, IEmployeeWrite employeeWrite)
        {
            _employeeRead = employeeRead;
            _employeeWrite = employeeWrite;
        }
        [HttpGet]
        public IActionResult GetAll(bool tracking = false)
        {
            var query = _employeeRead.GetAll();
            if(query != null)
            {
                return Ok(query);
            }else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(VM_CreateEmployee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(emp);
            }
            else
            {
                await _employeeWrite.AddAsync(new()
                {
                    Name = emp.Name,
                    Surname = emp.Surname,
                    Position = emp.Position
                });
                await _employeeWrite.SaveAsync();
                return Ok(true);
            }            
        }
        
    }
}
