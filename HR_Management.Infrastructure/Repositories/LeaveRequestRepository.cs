using HR_Management.Domain.Entities;
using HR_Management.Domain.Repositories;
using HR_Management.Infrastructure.Context;

namespace HR_Management.Infrastructure.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly HRDbContext _context;
    public LeaveRequestRepository(HRDbContext context) : base(context)
    {
        _context = context;
    }
}
