using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace OSNWebProject.Data
{
    public class OSNWebProjectContext : DbContext
    {
        public OSNWebProjectContext (DbContextOptions<OSNWebProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Core.Entities.Term> Term { get; set; }
    }
}
