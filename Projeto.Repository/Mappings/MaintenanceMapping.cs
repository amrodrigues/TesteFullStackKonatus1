using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;


namespace Projeto.Repository.Mappings
{
    public class MaintenanceMapping : EntityTypeConfiguration<Maintenance>
    {
        public MaintenanceMapping()
        {
            ToTable("Maintenance");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(m => m.Description)
                     .HasColumnName("Description")
                     .HasMaxLength(50)
                     .IsRequired();

            Property(m=> m.Status)
                .HasColumnName("Status")
                .IsRequired();

       
            Property(m => m.CreatedAt)
             .HasColumnName("CreatedAt")
             .IsRequired();

            Property( m => m.UserId)
              .HasColumnName("UserId")
             .IsRequired();

            HasRequired(m => m.Users)
              .WithMany(u => u.Maintenances)
              .HasForeignKey(m => m.UserId);
        }

    }
}
