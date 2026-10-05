using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPortal.Entities.Entities
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        public string Name { get; set; }
        public char Type { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
