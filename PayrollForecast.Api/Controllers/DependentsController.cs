using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayrollForecast.Api.Dtos;
using PayrollForecast.Api.Entities;
using PayrollForecast.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class DependentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DependentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET api/employees/{employeeid}/dependents
        [HttpGet("{employeeid}/dependents")]
        public async Task<IActionResult> Get(int employeeid)
        {
            if (!await _unitOfWork.Employees.Exists(employeeid))
                return NotFound();

            var dependentsFromRepo = await _unitOfWork.Dependents.GetDependentsByEmployeeId(employeeid);
            var dependents = _mapper.Map<IEnumerable<DependentDto>>(dependentsFromRepo);

            return Ok(dependents);
        }

        // GET api/employees/{employeeid}/dependents/{dependentid}
        [HttpGet("{employeeid}/dependents/{dependentid}")]
        public async Task<IActionResult> Get(int employeeid, int dependentid)
        {
            if (!await _unitOfWork.Employees.Exists(employeeid))
                return NotFound();

            var dependentFromRepo = await _unitOfWork.Dependents.GetDependentById(dependentid);
            if (dependentFromRepo == null)
                return NotFound();

            var dependent = _mapper.Map<DependentDto>(dependentFromRepo);

            return Ok(dependent);
        }

        // POST api/employees/{employeeid}/dependents
        [HttpPost("{employeeid}/dependents")]
        public async Task<IActionResult> Post([FromBody]DependentDto newDependent, int employeeid)
        {
            if (ModelState.IsValid)
            {
                var newDependentForRepo = _mapper.Map<Dependent>(newDependent);
                newDependentForRepo.EmployeeId = employeeid;
                await _unitOfWork.Dependents.Add(newDependentForRepo);

                if (await _unitOfWork.Complete())
                    return Created($"api/employees/{employeeid}/dependents/{newDependentForRepo.Id}", _mapper.Map<DependentDto>(newDependentForRepo));
                else
                    return BadRequest("Failed to save changes");
            }

            return BadRequest("Bad Data");
        }

        [HttpPut("{employeeid}/dependents/{dependentid}")]
        public async Task<IActionResult> Put([FromBody]DependentDto updateDependent, int employeeid, int dependentid)
        {
            if (updateDependent == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _unitOfWork.Employees.Exists(employeeid))
                return NotFound();

            if (!await _unitOfWork.Dependents.Exists(dependentid))
                return NotFound();

            await _unitOfWork.Dependents.Update(_mapper.Map<Dependent>(updateDependent));

            if (!await _unitOfWork.Complete())
                return StatusCode(500, "A problem happened while handling your request");

            return NoContent();
        }

        [HttpDelete("{employeeid}/dependents/{dependentid}")]
        public async Task<IActionResult> Delete(int employeeid, int dependentid)
        {
            if (!await _unitOfWork.Employees.Exists(employeeid))
                return NotFound();

            var dependent = await _unitOfWork.Dependents.GetDependentById(dependentid);

            if (dependent == null)
                return NotFound();

            _unitOfWork.Dependents.Remove(dependent);

            if (!await _unitOfWork.Complete())
                return StatusCode(500, "A problem happened while handling your request");

            return NoContent();
        }
    }
}