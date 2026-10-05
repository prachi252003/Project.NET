using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TrainingPortal.DAL.Repositories;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.WebApi.Controllers
{
    //[Authorize(Roles ="Admin,Trainer")]
    [AllowAnonymous]
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private EmployeeRepository repository;
        public EmployeeController()
        {
            repository = new EmployeeRepository();
        }

        //GET: api/employee
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEmployees()
        {
            try
            {
                return Ok(repository.GetAllEmployees());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/employee/1001
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            try
            {
                Employee employee = repository.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/employee
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddEmployee(Employee employee)
        {
            try
            {
                bool result =
                repository.AddEmployee(employee);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/employee
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                bool result =
                repository.UpdateEmployee(employee);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/employee/1001
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            try
            {
                bool result =
                repository.DeleteEmployee(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}