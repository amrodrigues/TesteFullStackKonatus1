using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;


namespace Projeto.Repository.Mappings
{
   public class StageMapping : EntityTypeConfiguration<Stage>
    {
        public StageMapping()
        {
            ToTable("Stage");

            HasKey(s=>s.Id);

            Property(s => s.Id)
               .HasColumnName("Id")
               .IsRequired();

            Property(s => s.Description)
                   .HasColumnName("Description")
                   .HasMaxLength(50)
                   .IsRequired();

            Property(s => s.Status)
                .HasColumnName("Status")
                .IsRequired();

            Property(s => s.Type)
               .HasColumnName("Type")
               .IsRequired();

            Property(s => s.Value)
                   .HasColumnName("Value")
                   .HasMaxLength(50)
                   .IsRequired();

            Property(s => s.CreatedAt)
             .HasColumnName("CreatedAt")
             .IsRequired();

            Property(s => s.MaintenanceId)
                .HasColumnName("MaintenanceId")
                 .IsRequired();

            HasRequired(s => s.Maintenance)
               .WithMany(m => m.Stages)
                .HasForeignKey(s => s.MaintenanceId);

        }
    }
}
