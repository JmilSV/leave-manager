using LeaveManager.Data.Entities;
using LeaveManager.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManager.Data.Repositories
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext context;
        public LeaveTypeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<LeaveType>> GetAllAsync()
        {
            return await context.LeaveTypes.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public Task<LeaveType> GetAsync(int id)
        {
            return context.LeaveTypes.FirstOrDefaultAsync(it => it.Id == id);
        }

        public async Task<bool> CreateAsync(LeaveType entity)
        {
            await context.LeaveTypes.AddAsync(entity).ConfigureAwait(false);
            return await SaveAsync().ConfigureAwait(false) == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await IsExistAsync(id))
                throw new Exception($"Entity with {id} doesn't exist!");

            var leaveType = await GetAsync(id).ConfigureAwait(false);
            context.LeaveTypes.Remove(leaveType);
            return await SaveAsync().ConfigureAwait(false) == 1;
        }

        public async Task<bool> UpdateAsync(LeaveType leaveType)
        {
            if (leaveType == null)
                throw new ArgumentNullException(paramName: nameof(leaveType));
            if (!await IsExistAsync(leaveType.Id))
                throw new Exception($"Entity with {leaveType.Id} doesn't exist!");

            context.LeaveTypes.Update(leaveType);
            return await SaveAsync().ConfigureAwait(false) == 1;
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await context.LeaveTypes.AsNoTracking()
                .AnyAsync(it => it.Id == id).ConfigureAwait(false);
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
