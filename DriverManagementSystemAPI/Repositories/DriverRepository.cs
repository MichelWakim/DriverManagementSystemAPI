using System.Collections.Generic;
using System.Globalization;
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

        public async Task<IEnumerable<Driver>?> GetAllDrivers(string? sortBy = null, string? sortOrder = null, string? searchTerm = null)
        {
            using var fileStream = File.OpenRead(_filePath);
            var drivers = await JsonSerializer.DeserializeAsync<List<Driver>>(fileStream);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                drivers = drivers?.Where(
                    d => d.FirstName.ToLower().Contains(searchTerm.ToLower())
                    || d.LastName.ToLower().Contains(searchTerm.ToLower())
                    || d.Email.ToLower().Contains(searchTerm.ToLower())
                    || d.PhoneNumber.ToLower().Contains(searchTerm.ToLower())
                    ).ToList();
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "firstname":
                        drivers = sortOrder?.ToLower() == "desc"
                            ? drivers?.OrderByDescending(d => d.FirstName).ToList()
                            : drivers?.OrderBy(d => d.FirstName).ToList();
                        break;
                    case "lastname":
                        drivers = sortOrder?.ToLower() == "desc"
                            ? drivers?.OrderByDescending(d => d.LastName).ToList()
                            : drivers?.OrderBy(d => d.LastName).ToList();
                        break;
                    case "id":
                        drivers = sortOrder?.ToLower() == "desc"
                           ? drivers?.OrderByDescending(d => d.Id).ToList()
                           : drivers?.OrderBy(d => d.Id).ToList();
                        break;
                    default:
                        break;
                }
            }

            return drivers;
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