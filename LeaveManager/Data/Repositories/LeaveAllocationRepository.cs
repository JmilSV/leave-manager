using LeaveManager.Data.Contracts;
using LeaveManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManager.Data.Repositories
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        public LeaveAllocationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<LeaveAllocation>> GetAllAsync()
        {
            return await context.LeaveAllocations.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public Task<LeaveAllocation> GetAsync(int id)
        {
            return context.LeaveAllocations.FirstOrDefaultAsync(it => it.Id == id);
        }

        public async Task<bool> CreateAsync(LeaveAllocation entity)
        {
            await context.LeaveAllocations.AddAsync(entity).ConfigureAwait(false);
            return await SaveAsync().ConfigureAwait(false) == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var leaveType = await GetAsync(id).ConfigureAwait(false);
            if (leaveType == null)
                return false;

            context.LeaveAllocations.Remove(leaveType);
            return await SaveAsync().ConfigureAwait(false) == 1;
        }

        public async Task<bool> UpdateAsync(LeaveAllocation entity)
        {
            context.LeaveAllocations.Update(entity);
            return await SaveAsync().ConfigureAwait(false) == 1;
        }

        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
