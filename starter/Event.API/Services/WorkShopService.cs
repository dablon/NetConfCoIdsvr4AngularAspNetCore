using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.API.Data;
using Event.API.Domain;
using Event.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event.API.Services
{
    public class WorkShopService: IWorkShopService, IDisposable
    {
        private readonly EventDbContext _context;

        public WorkShopService(EventDbContext context)
        {
            _context = context;
        }
        public async Task SaveWorkshop(WorkShop workShop)
        {
            await _context.WorkShops.AddAsync(workShop);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<WorkShop>> Get()
        {
            return await _context.WorkShops.ToListAsync();
        }

        public Task<ICollection<WorkShop>> GetWithUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventUser>> GetWorkshopUsers(Guid workShopGuid)
        {
            throw new NotImplementedException();
        }

        public Task SubscribeToWorkShop(Guid workShopGuid, Guid userGuid)
        {
            throw new NotImplementedException();
        }

        public Task UnSubscribeToWorkShop(Guid workShopGuid, Guid userGuid)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
