using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
     
            builder.HasData(
                new Patient
                {
                    Id = 1,
                    FirstName = "Maria",
                    LastName = "Ivanova",
                    Email = "maria.ivanova@gmail.com",
                    PhoneNumber = "+359887111222"
                },
                new Patient
                {
                    Id = 2,
                    FirstName = "Nikolay",
                    LastName = "Georgiev",
                    Email = "nikolay.georgiev@abv.bg",
                    PhoneNumber = "+359888333444"
                },
                new Patient
                {
                    Id = 3,
                    FirstName = "Petya",
                    LastName = "Kolevа",
                    Email = "petya.koleva@gmail.com",
                    PhoneNumber = "+359889555666"
                }
            );
        }
    }
}
