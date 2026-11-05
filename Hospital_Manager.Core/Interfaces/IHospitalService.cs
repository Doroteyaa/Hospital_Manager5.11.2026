using Data_Hospital_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Manager.Core.Interfaces
{
    public interface IHospitalService
    {
        Task<List<Hospital>> GetAllHospitalsAsync(string? search=null,int? minbeds=null,string? sortord=null);
        Task<Hospital?> GetHospitalByIdAsync(int id);
        Task AddHospitalAsync(Hospital hospital);
        Task DeleteHospitalAsync(int id);
        Task UpdateHospitalAsync(Hospital hospital);
     

    }
}
