using EmployeesMapping.App.Core.Dtos;

namespace EmployeesMapping.App.Core.Contracts
{
    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto GetManagerInfo(int employeeId);
    }
}
