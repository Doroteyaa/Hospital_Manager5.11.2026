using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Hospital_Manager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Manager.Core.Services
{
    public class DoctorService:IDoctorInterface
    {
        private readonly HospitalDbContext context;

        public DoctorService(HospitalDbContext context)
        {
            this.context = context;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
          context.Doctors.Add(doctor);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await context.Doctors.Include(x=>x.DPatients)
                .FirstOrDefaultAsync(x=>x.Id==id);
            if (doctor != null)
            {
                context.DoctorPatients.RemoveRange(doctor.DPatients);
                context.Doctors.Remove(doctor);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync(string? search , string? specialty , string? sortord )
        {
            var query = context.Doctors.Include(x => x.Hospital).Where(x => true);
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.FirstName.Contains(search) ||
                x.LastName.Contains(search));
            }
            if (!string.IsNullOrWhiteSpace(specialty))
            {
                query = query.Where(x => x.Specialty.Contains(specialty));
            }
            switch (sortord)
            {
                case "name_asc":
                    query = query.OrderBy(c => c.FirstName).ThenBy(x => x.LastName);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(c => c.FirstName).ThenByDescending(x => x.LastName);
                    break;
                case "specialty":
                    query = query.OrderBy(c => c.Specialty).ThenBy(x => x.FirstName);
                    break;
                default:
                    query = query.OrderBy(c => c.FirstName).ThenBy(x => x.LastName);
                    break;
            }
            return await query.ToListAsync();
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await context.Doctors
                .Include(d => d.DPatients)
                .Include(d => d.Hospital)
                .FirstOrDefaultAsync();
        }

        public async Task<Doctor?> GetDoctorDetailsAsync(int id)
        {
            return await context.Doctors.Include(d=>d.Hospital)
                .Include(x=>x.DPatients).ThenInclude(x=>x.Patient)
                .FirstOrDefaultAsync(d=>d.Id==id);  
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            await context.SaveChangesAsync();
        }
    }
}
