﻿using Application.Repostories.EmployeeRepository;
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
        public IActionResult GetAll()
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
        public async Task<IActionResult> GetbyIDAsync(string ID)
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
        public async Task<IActionResult> GetSingleAsync(string name)
        {
            var query = await _employeeRead.GetSingleAsync(item => item.Name.ToLower() == name.ToLower());
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
