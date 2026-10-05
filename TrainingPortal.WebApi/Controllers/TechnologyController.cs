using System;
using System.Web.Http;
using TrainingPortal.DAL.Repositories;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.WebAPI.Controllers
{
   // [Authorize]
    [RoutePrefix("api/technology")]
    public class TechnologyController : ApiController
    {
        private TechnologyRepository repository;

        public TechnologyController()
        {
            repository = new TechnologyRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTechnologies()
        {
            return Ok(repository.GetAllTechnologies());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetTechnologyById(int id)
        {
            try
            {
                return Ok(repository.GetTechnologyById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddTechnology(Technology technology)
        {
            return Ok(repository.AddTechnology(technology));
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateTechnology(Technology technology)
        {
            return Ok(repository.UpdateTechnology(technology));
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteTechnology(int id)
        {
            return Ok(repository.DeleteTechnology(id));
        }
    }
}