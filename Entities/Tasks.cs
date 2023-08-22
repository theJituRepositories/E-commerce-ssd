using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string TaskCategory { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

    }

    
}
