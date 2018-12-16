using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiWithTesting.Domain.Entities;
using WebApiWithTesting.Domain.Repositories;

namespace WebApiWithTesting.Data.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly AppContext _context;

        public HouseRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await GetByIdAsync(id) != null;
        }

        public async Task<House> GetByIdAsync(int id)
        {
            return await _context.House.FindAsync(id);
        }

        public async Task<ICollection<House>> GetAllAsync()
        {
            return await _context.House.ToListAsync();
        }

        public async Task<House> AddAsync(House entity)
        {
            _context.House.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(House entity)
        {
            if (!await Exists(entity.HouseId))
                return false;
            _context.House.Update(entity);

            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int entityId)
        {
            if (!await Exists(entityId))
                return false;
            var toRemove = _context.House.Find(entityId);
            _context.House.Remove(toRemove);
            await _context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}