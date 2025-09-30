using HR_Management.Domain.Entities;
using HR_Management.Domain.Repositories;
using HR_Management.Infrastructure.Context;

namespace HR_Management.Infrastructure.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly HRDbContext _context;
    public LeaveAllocationRepository(HRDbContext context) : base(context)
    {
        _context = context;
    }
}
