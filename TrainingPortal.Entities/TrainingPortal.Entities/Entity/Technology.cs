using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPortal.Entities.Entities
{
    public class Technology
    {
        public int TechnologyId { get; set; }
        public string Name { get; set; }
        public char Level { get; set; }
        public int Duration { get; set; }
    }
}
