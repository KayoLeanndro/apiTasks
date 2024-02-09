using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace apiTasks.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }

        public DbSet<TaskToMade> TaskToMades {get; set;}
    }
}