using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopServiceRepository : ICarWorkshopServiceRepository
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopServiceRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(CarWorkshopService service)
        {
            _dbContext.CarWorkshopServices.Add(service);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CarWorkshopService?> GetById(int id)
        {
            return await _dbContext.CarWorkshopServices
                .Include(s => s.CarWorkshop)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<CarWorkshopService>> GetByWorkshopId(int workshopId)
        {
            return await _dbContext.CarWorkshopServices
                .Where(s => s.CarWorkshopId == workshopId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CarWorkshopService>> GetAll()
        {
            return await _dbContext.CarWorkshopServices.ToListAsync();
        }

        public async Task Update(CarWorkshopService service)
        {
            _dbContext.CarWorkshopServices.Update(service);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(CarWorkshopService service)
        {
            _dbContext.CarWorkshopServices.Remove(service);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
