using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Hospital_Manager.Migrations
{
    /// <inheritdoc />
    public partial class heheehe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "BedsCount", "CreatedOn", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "66 Peshtersko Shose Blvd, Plovdiv", 1500, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@stgeorgehospital.bg", false, "St. George University Hospital", "35932602111" },
                    { 2, "51B Nikola Vaptsarov Blvd, Sofia", 1000, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@tokudahospital.bg", false, "Tokuda Hospital Sofia", "35924034000" },
                    { 3, "56 Hristo Botev Blvd, Kazanlak", 260, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "office@mbal-kazanlak.bg", false, "Dr. Hristo Stambolski Hospital", "35943162200" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "maria.ivanova@gmail.com", "Maria", "Ivanova", "+359887111222" },
                    { 2, "nikolay.georgiev@abv.bg", "Nikolay", "Georgiev", "+359888333444" },
                    { 3, "petya.koleva@gmail.com", "Petya", "Kolevа", "+359889555666" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "FirstName", "HospitalId", "LastName", "PhoneNumber", "Specialty" },
                values: new object[,]
                {
                    { 1, "ivan.petrov@stgeorgehospital.bg", "Ivan", 1, "Petrov", "359888123456", "Cardiology" },
                    { 2, "elena.dimitrova@tokudahospital.bg", "Elena", 2, "Dimitrova", "359889234567", "Neurology" },
                    { 3, "georgi.stoyanov@mbal-kazanlak.bg", "Georgi", 3, "Stoyanov", "359887345678", "Orthopedics" }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatients",
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
