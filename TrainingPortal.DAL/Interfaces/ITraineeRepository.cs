using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface ITraineeRepository
    {
        List<Trainee> GetAllTrainees();
        Trainee GetTraineeById(int trainingId, int empId);

        bool AddTrainee(Trainee trainee);

        bool UpdateTrainee(Trainee trainee);

        bool DeleteTrainee(int trainingId, int empId);
    }
}
