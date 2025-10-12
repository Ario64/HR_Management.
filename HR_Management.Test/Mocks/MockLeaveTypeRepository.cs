using HR_Management.Domain.Repositories;
using Moq;

namespace HR_Management.Test.Mocks;

public static class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
    {
        var leaveTypes = new List<HR_Management.Domain.Entities.LeaveType>
        {
            new ()
            {
                Id = 1,
                LeaveTypeTitle = "Annual Leave",
                DefaultDays = 20
            },
            new ()
            {
                Id = 2,
                LeaveTypeTitle = "Sick Leave",
                DefaultDays = 10
            }
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();

        mockRepo.Setup(repo => repo.GetAllAsync(It.IsAny<CancellationToken>()))
                                   .ReturnsAsync(leaveTypes);

        mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                                   .ReturnsAsync((int id, CancellationToken ct) => leaveTypes
                                   .FirstOrDefault(x => x.Id == id));

        mockRepo.Setup(repo => repo.Add(It.IsAny<HR_Management.Domain.Entities.LeaveType>()))
                                   .Callback((HR_Management.Domain.Entities.LeaveType leaveType) =>
                                   {
                                       leaveTypes.Add(leaveType);
                                   });

        return mockRepo;
    }
}
