using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface ITrainerRepository
    {
        List<Trainer> GetAllTrainers();

        Trainer GetTrainerById(int id);

        bool AddTrainer(Trainer trainer);

        bool UpdateTrainer(Trainer trainer);

        bool DeleteTrainer(int id);
    }
}
