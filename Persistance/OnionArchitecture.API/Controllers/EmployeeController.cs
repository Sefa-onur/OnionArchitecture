using Application.Repostories.EmployeeRepository;
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
        [HttpGet("GetByIDAsync/{ID}")]
        public async Task<IActionResult> GetbyIDAsync(string ID,bool tracking = false)
        {
            var query = await _employeeRead.GetbyIDAsync(ID);
            if(query != null)
            {
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("GetSingleAsync/{Name}")]
        public async Task<IActionResult> GetSingleAsync(string Name, bool tracking = false)
        {
            var query = await _employeeRead.GetSingleAsync(item => item.Name.ToLower() == Name.ToLower());
            if( query != null)
            {
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
