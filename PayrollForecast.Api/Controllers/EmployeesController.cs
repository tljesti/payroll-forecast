using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayrollForecast.Api.BusinessLogic;
using PayrollForecast.Api.Dtos;
using PayrollForecast.Api.Entities;
using PayrollForecast.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmployeeBusinessLogic _employeeBusinessLogic;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeBusinessLogic employeeBusinessLogic)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _employeeBusinessLogic = employeeBusinessLogic;
        }

        // GET api/employees
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employeesFromBL = await _employeeBusinessLogic.GetEmployeesWithYearlyPayment();
            var employees = _mapper.Map<IEnumerable<EmployeeWithYearlyPaymentDto>>(employeesFromBL);

            return Ok(employees);
        }

        // GET api/employees/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employeeFromBL = await _employeeBusinessLogic.GetEmployeeByIdWithYearlyPaymentAndSummary(id);

            if (employeeFromBL == null)
                return NotFound();

            var employee = _mapper.Map<EmployeeWithYearlyPaymentAndSummaryDto>(employeeFromBL);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmployeeDto newEmployee)
        {
            if (ModelState.IsValid)
            {
                var newEmployeeForRepo = _mapper.Map<Employee>(newEmployee);
                await _unitOfWork.Employees.Add(newEmployeeForRepo);

                if (await _unitOfWork.Complete())
                    return Created($"api/employees/{newEmployeeForRepo.Id}", _mapper.Map<EmployeeDto>(newEmployeeForRepo));
                else
                    return BadRequest("Failed to save changes");
            }
            
            return BadRequest("Bad Data");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]EmployeeDto updateEmployee)
        {
            if (updateEmployee == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _unitOfWork.Employees.Exists(id))
                return NotFound();

            await _unitOfWork.Employees.Update(_mapper.Map<Employee>(updateEmployee));

            if (!await _unitOfWork.Complete())
                return StatusCode(500, "A problem happened while handling your request");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _unitOfWork.Employees.GetById(id);

            if (employee == null)
                return NotFound();

            _unitOfWork.Employees.Remove(employee);

            if (!await _unitOfWork.Complete())
                return StatusCode(500, "A problem happened while handling your request");

            return NoContent();
        }
    }
}