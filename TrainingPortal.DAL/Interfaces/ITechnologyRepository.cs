using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface ITechnologyRepository
    {
        List<Technology> GetAllTechnologies();

        Technology GetTechnologyById(int id);

        bool AddTechnology(Technology technology);

        bool UpdateTechnology(Technology technology);

        bool DeleteTechnology(int id);
    }
}
