using AutoMapper;
using HR_Management.Domain.Repositories;
using HR_Management.Test.Mocks;
using Moq;

namespace HR_Management.Test.LeaveType.Queries;

public class GetLeaveTypeListRequestHandlerTest
{
    private readonly Mock<ILeaveTypeRepository> _mock;
    private readonly IMapper _mapper;

    public GetLeaveTypeListRequestHandlerTest(IMapper mapper)
    {
        _mock = new MockLeaveTypeRepository.GetLeaveTypeRepository();
        _mapper = mapper;
    }


}
