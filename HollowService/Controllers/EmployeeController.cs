using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollowService.Interfaces;
using HollowService.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HollowService.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repo = repository;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await _repo.GetEmployementsAsync();
            return Ok(employees);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _repo.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> AddEmployee ([FromBody]Employee employee)
        {
           await _repo.AddEmployeeAsync(employee);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeById(int id, [FromBody]Employee employee)
        {
            employee.Id = id;
            await _repo.UpdateEmployeeByIdAsync(id, employee);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = 0;
            result = await _repo.DeleteEmployeeByIdAsync(id);
            if (result == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
