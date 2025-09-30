using HR_Management.Domain.Entities;
using HR_Management.Domain.Repositories;
using HR_Management.Infrastructure.Context;

namespace HR_Management.Infrastructure.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly HRDbContext _context;
    public LeaveTypeRepository(HRDbContext context) : base(context)
    {
        _context = context;
    }
}
