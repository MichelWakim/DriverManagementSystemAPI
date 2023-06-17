using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverManagementSystemAPI.Models;
using DriverManagementSystemAPI.Repositories;
using DriverManagementSystemAPI.Utilities;

namespace DriverManagementSystemAPI.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _repository;

        public DriverService(IDriverRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Driver>?> GetAllDrivers()
        {
            return await _repository.GetAllDrivers();
        }

        public async Task<Driver?> GetDriverById(int id)
        {
            return await _repository.GetDriverById(id);
        }

        public async Task<Driver> CreateDriver(Driver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }

            return await _repository.CreateDriver(driver);
        }

        public async Task<Driver?> UpdateDriver(int id, Driver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }
            var oldDriver = await GetDriverById(id);
            if (oldDriver == null)
            {
                throw new CustomException(1,404 , $"driver with id: {id} is not found");
            }

            return await _repository.UpdateDriver(id, driver);
        }

        public async Task DeleteDriver(int id)
        {
            await _repository.DeleteDriver(id);
        }
    }
}