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
    public class DoctorConfiguration:IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(x=>x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Specialty).IsRequired();
            builder.HasOne(d=>d.Hospital).WithMany(h=>h.Doctors).HasForeignKey(x=>x.HospitalId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=>x.User).WithOne(x=>x.Doctor).HasForeignKey<Doctor>(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
            new Doctor
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Petrov",
                Specialty = "Cardiology",
                Email = "ivan.petrov@stgeorgehospital.bg",
                PhoneNumber = "359888123456",
                HospitalId = 1
            },
            new Doctor
            {
                Id = 2,
                FirstName = "Elena",
                LastName = "Dimitrova",
                Specialty = "Neurology",
                Email = "elena.dimitrova@tokudahospital.bg",
                PhoneNumber = "359889234567",
                HospitalId = 2
            },
            new Doctor
            {
                Id = 3,
                FirstName = "Georgi",
                LastName = "Stoyanov",
                Specialty = "Orthopedics",
                Email = "georgi.stoyanov@mbal-kazanlak.bg",
                PhoneNumber = "359887345678",
                HospitalId = 3
            }
        );
        }

       
    }
}
