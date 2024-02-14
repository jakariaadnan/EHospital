﻿using HospitalManagementSystem.Data.Entity;
using HospitalManagementSystem.Data.Entity.MasterData;

namespace HospitalManagementSystem.Services.Interfaces
{
    public interface IDoctorServices
    {
        Task<IEnumerable<Doctor>> GetDoctorList();
        Task<Doctor> GetDoctorById(int id);
        Task<bool> SaveDoctor(Doctor doctor);
        Task<bool> DeleteDoctorById(int id);
    }
}
