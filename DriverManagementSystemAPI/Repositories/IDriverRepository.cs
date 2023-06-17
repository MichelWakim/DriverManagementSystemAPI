using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DriverManagementSystemAPI.Models;

namespace DriverManagementSystemAPI.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>?> GetAllDrivers();
        Task<Driver?> GetDriverById(int id);
        Task<Driver> CreateDriver(Driver driver);
        Task<Driver?> UpdateDriver(int id, Driver driver);
        Task DeleteDriver(int id);
    }
}

