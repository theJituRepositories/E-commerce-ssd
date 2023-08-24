using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models.Tasks
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public string? TaskCategory { get; set; }
        public string? Description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

    }
}