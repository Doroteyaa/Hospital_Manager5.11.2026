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
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.HasData(
            new Hospital
            {
                Id = 1,
                Name = "St. George University Hospital",
                Address = "66 Peshtersko Shose Blvd, Plovdiv",
                Email = "contact@stgeorgehospital.bg",
                PhoneNumber = "35932602111",
                BedsCount = 1500,
                CreatedOn = new DateTime(2026, 1, 15),
                IsDeleted = false
            },
            new Hospital
            {
                Id = 2,
                Name = "Tokuda Hospital Sofia",
                Address = "51B Nikola Vaptsarov Blvd, Sofia",
                Email = "info@tokudahospital.bg",
                PhoneNumber = "35924034000",
                BedsCount = 1000,
                CreatedOn = new DateTime(2026, 2, 10),
                IsDeleted = false
            },
            new Hospital
            {
                Id = 3,
                Name = "Dr. Hristo Stambolski Hospital",
                Address = "56 Hristo Botev Blvd, Kazanlak",
                Email = "office@mbal-kazanlak.bg",
                PhoneNumber = "35943162200",
                BedsCount = 260,
                CreatedOn = new DateTime(2026, 3, 5),
                IsDeleted = false
            }
        );
        }
    }
}
