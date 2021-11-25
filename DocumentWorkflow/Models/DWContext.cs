using Microsoft.EntityFrameworkCore;
using DocumentWorkflow.Models.Entities;
using DocumentWorkflow.Models.EntityTypeConfigurations;

namespace DocumentWorkflow.Models
{
    public class DWContext : DbContext
    {
        public virtual DbSet<IncomingDocument> IncomingDocuments { get; set; }
        public virtual DbSet<OutgoingDocument> OutgoingDocuments { get; set; }

        public DWContext(DbContextOptions<DWContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IncomingDocumentConfiguration());
            modelBuilder.ApplyConfiguration(new OutgoingDocumentConfiguration());
        }
    }
}