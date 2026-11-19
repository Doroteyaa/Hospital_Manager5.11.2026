using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Hospital_Manager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Manager.Core.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly HospitalDbContext context;

        public HospitalService(HospitalDbContext context)
        {
            this.context = context;
        }

        public async Task AddHospitalAsync(Hospital hospital)
        {
            context.Hospitals.Add(hospital);     
            await context.SaveChangesAsync();
        }

        public async Task DeleteHospitalAsync(int id)
        {
            var hospital = await context.Hospitals.FindAsync(id);
            if (hospital == null)
            {
                return;
            }
           bool hasDoctors=await  context.Doctors.AnyAsync(x=>x.HospitalId==id);
            if (hasDoctors)
            {
                throw new InvalidOperationException("Cant be deleted");
            }
            hospital.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<List<Hospital>> GetAllHospitalsAsync(string? search, int? minbeds , string? sortord)
        {

            var query= context.Hospitals.Where(x => !x.IsDeleted);
            if (!string.IsNullOrWhiteSpace(search))
            {
                  query=query.Where(x=>x.Name.Contains(search));
            }
            if (minbeds.HasValue)
            {
                query=query.Where(x=>x.BedsCount>=minbeds.Value);
            }
            switch(sortord)
            {
                case "name":
                    query=query.OrderBy(x=>x.Name);
                    break;

                case "beds_asc":
                     query=query.OrderBy(x=>x.BedsCount);
                    break;
                case "beds_desc":
                    query = query.OrderByDescending(x => x.BedsCount);
                    break;
                default:
                    query = query.OrderBy(x => x.Name);
                    break;
            }
            return await query.ToListAsync();
        }

  

        public async Task<Hospital?> GetHospitalByIdAsync(int id)
        {
            return await context.Hospitals.FindAsync(id);
        }

        public async Task UpdateHospitalAsync(Hospital hospital)
        {
            await context.SaveChangesAsync();
        }
    }
}
