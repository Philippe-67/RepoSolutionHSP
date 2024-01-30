using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAgendaPraticien.Model;

namespace ServiceAgendaPraticien.Data
{
    public class ServiceAgendaPraticienContext : DbContext
    {
        public ServiceAgendaPraticienContext (DbContextOptions<ServiceAgendaPraticienContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceAgendaPraticien.Model.Praticien> Praticien { get; set; } = default!;
    }
}
