namespace Company.Common.DTOs;

public class EmployeeTitleDTO
{
    public int EmployeeId { get; set; } = default;

    public int TitleId { get; set; }= default;

    public EmployeeTitleDTO(int employeeId, int titleId)
    {
        EmployeeId = employeeId;
        TitleId = titleId;
    }
}
