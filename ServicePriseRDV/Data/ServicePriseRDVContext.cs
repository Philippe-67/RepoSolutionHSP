using Microsoft.EntityFrameworkCore;
using ServicePriseRDV.Model;

namespace ServicePriseRDV.Data
{
    public class ServicePriseRDVContext : DbContext
    {
        public ServicePriseRDVContext (DbContextOptions<ServicePriseRDVContext> options)
            : base(options)
        {
        }

        public DbSet<RendezVous> RendezVous { get; set; } = default!;
    }
}
