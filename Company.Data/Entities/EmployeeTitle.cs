using Company.Data.Interfaces;

namespace Company.Data.Entities;


public class EmployeeTitle : IReferenceEntity
{
    public int EmployeeId { get; set; }

    public int TitleId { get; set; }

    public Employee? employee { get; set; }

    public Title? title { get; set;  }


}
