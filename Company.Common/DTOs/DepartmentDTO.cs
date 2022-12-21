using System.ComponentModel.DataAnnotations;

namespace Company.Common.DTOs;

public class DepartmentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
}
