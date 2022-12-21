using System.ComponentModel.DataAnnotations;

namespace Company.Common.DTOs;


public class EmployeeDTO
{
    public int Id { get; set; }
    public string FirtName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
    public bool HasUnion { get; set; }
    public int DepartmentId { get; set; }
}
