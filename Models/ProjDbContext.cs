using Microsoft.EntityFrameworkCore;


namespace CW_PD8.Models
{
    public class ProjDbContext : DbContext
    {
            public ProjDbContext() {

            }

            public ProjDbContext(DbContextOptions<ProjDbContext> options) : base(options)
            {

            }

            public virtual DbSet<Doctor> Doctors { get; set; }
            public virtual DbSet<Perscription> Prescriptions { get; set; }
            public virtual DbSet<Patient> Patients { get; set; }
            public virtual DbSet<Medicament> Medicaments { get; set; }
            public virtual DbSet<Perscription_Medicament> Perscription_Medicaments { get; set; }

            public virtual DbSet<User> Users { get; set; }

    }
}
