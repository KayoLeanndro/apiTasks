using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiTasks.Context;
using apiTasks.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiTasks.Models
{
    public class TaskToMade 
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Status TaskStatus { get; set; }
    }
}