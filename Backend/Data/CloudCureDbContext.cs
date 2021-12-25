using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;
using Models.Diagnosis;

namespace Data
{
    public class CloudCureDbContext : DbContext
    {
        public CloudCureDbContext(DbContextOptions<CloudCureDbContext> options) : base(options) { }

        public virtual DbSet<Allergy> Allergies { get; set; }
        public virtual DbSet<Assessment> Assessments { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Surgery> Surgeries { get; set; }
        public virtual DbSet<Vitals> Vitals { get; set; }
        public virtual DbSet<CovidVerify> CovidAssessments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<EmployeeInformation> Employee { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
    }
}