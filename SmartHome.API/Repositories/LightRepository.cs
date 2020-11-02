using Microsoft.EntityFrameworkCore;
using SmartHome.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHome.API.Repositories
{
    public class LightRepository
    {
        private readonly SmartHomeContext _context;

        public LightRepository(SmartHomeContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<List<Light>> GetAllAsync()
        {
            return await _context.Lights.ToListAsync();
        }
    }
}
