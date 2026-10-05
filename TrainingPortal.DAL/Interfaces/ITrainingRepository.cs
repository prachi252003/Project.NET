using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface ITrainingRepository
    {
        List<Training> GetAllTrainings();

        Training GetTrainingById(int id);

        bool AddTraining(Training training);

        bool UpdateTraining(Training training);

        bool DeleteTraining(int id);
    
}
}
