using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DriverManagementSystemAPI.Models;

namespace DriverManagementSystemAPI.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly string _filePath;

        public DriverRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<IEnumerable<Driver>?> GetAllDrivers()
        {
            using var fileStream = File.OpenRead(_filePath);
            return await JsonSerializer.DeserializeAsync<List<Driver>>(fileStream);
        }

        public async Task<Driver?> GetDriverById(int id)
        {
            var drivers = await GetAllDrivers() as List<Driver>;
            return drivers?.FirstOrDefault(d => d.Id == id);
        }

        public async Task<Driver> CreateDriver(Driver driver)
        {
            var drivers = await GetAllDrivers() as List<Driver> ?? new List<Driver>();
            driver.Id = drivers.Max(d => d.Id) + 1;
            drivers.Add(driver);
            using var fileStream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(fileStream, drivers);
            return driver;
        }

        public async Task<Driver?> UpdateDriver(int id, Driver driver)
        {
            var drivers = await GetAllDrivers() as List<Driver> ?? new List<Driver>();
            var index = drivers.FindIndex(d => d.Id == id);
            if (index != -1)
            {
                driver.Id = id;
                drivers[index] = driver;
                using var fileStream = File.Create(_filePath);
                await JsonSerializer.SerializeAsync(fileStream, drivers);
                return driver;
            }
            return null;
        }

        public async Task DeleteDriver(int id)
        {
            var drivers = await GetAllDrivers() as List<Driver> ?? new List<Driver>();
            var index = drivers.FindIndex(d => d.Id == id);
            if (index != -1)
            {
                drivers.RemoveAt(index);
                using var fileStream = File.Create(_filePath);
                await JsonSerializer.SerializeAsync(fileStream, drivers);
            }
        }
    }
}