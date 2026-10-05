using System;
using System.Web.Http;
using TrainingPortal.DAL.Repositories;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/trainer")]
    public class TrainerController : ApiController
    {
        private TrainerRepository repository;

        public TrainerController()
        {
            repository = new TrainerRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTrainers()
        {
            return Ok(repository.GetAllTrainers());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetTrainerById(int id)
        {
            try
            {
                return Ok(repository.GetTrainerById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddTrainer(Trainer trainer)
        {
            return Ok(repository.AddTrainer(trainer));
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateTrainer(Trainer trainer)
        {
            return Ok(repository.UpdateTrainer(trainer));
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteTrainer(int id)
        {
            return Ok(repository.DeleteTrainer(id));
        }
    }
}