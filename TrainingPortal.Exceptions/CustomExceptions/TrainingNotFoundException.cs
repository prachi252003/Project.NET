using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPortal.Exceptions.CustomExceptions
{
    public class TrainingNotFoundException : Exception
    {
        public TrainingNotFoundException() : base("Training not found") 
        { }
    }
}
