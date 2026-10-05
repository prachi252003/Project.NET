using System;
using System.Web.Http;
using TrainingPortal.DAL.Repositories;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/training")]
    public class TrainingController : ApiController
    {
        private TrainingRepository repository;

        public TrainingController()
        {
            repository = new TrainingRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTrainings()
        {
            return Ok(repository.GetAllTrainings());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetTrainingById(int id)
        {
            try
            {
                return Ok(repository.GetTrainingById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddTraining(Training training)
        {
            return Ok(repository.AddTraining(training));
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateTraining(Training training)
        {
            return Ok(repository.UpdateTraining(training));
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteTraining(int id)
        {
            return Ok(repository.DeleteTraining(id));
        }
    }
}