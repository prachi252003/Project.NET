using System;
using System.Web.Http;
using TrainingPortal.DAL.Repositories;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/trainee")]
    public class TraineeController : ApiController
    {
        private TraineeRepository repository;

        public TraineeController()
        {
            repository = new TraineeRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTrainees()
        {
            return Ok(repository.GetAllTrainees());
        }

        [HttpGet]
        [Route("{trainingId}/{empId}")]
        public IHttpActionResult GetTrainee(int trainingId, int empId)
        {
            try
            {
                return Ok(
                    repository.GetTraineeById(
                        trainingId,
                        empId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddTrainee(Trainee trainee)
        {
            return Ok(repository.AddTrainee(trainee));
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateTrainee(Trainee trainee)
        {
            return Ok(repository.UpdateTrainee(trainee));
        }

        [HttpDelete]
        [Route("{trainingId}/{empId}")]
        public IHttpActionResult DeleteTrainee(
            int trainingId,
            int empId)
        {
            return Ok(
                repository.DeleteTrainee(
                    trainingId,
                    empId));
        }
    }
}