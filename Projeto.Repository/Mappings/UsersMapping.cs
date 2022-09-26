using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;

namespace Projeto.Repository.Mappings
{
    public class UsersMapping :EntityTypeConfiguration<Users>
    {
        public UsersMapping()
        {
            ToTable("Users");

            HasKey(u => u.Id);

            Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(u => u.Login)
                .HasColumnName("Login")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.Password)
                .HasColumnName("Password")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.CreatedAt)
               .HasColumnName("CreatedAt")
               .IsRequired();

        }
    }
}
