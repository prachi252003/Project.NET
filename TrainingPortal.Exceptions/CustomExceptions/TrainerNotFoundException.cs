using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPortal.Exceptions.CustomExceptions
{
    public class TrainerNotFoundException : Exception
    {
        public TrainerNotFoundException() : base("Trainer not found")
        { }
    }
}
