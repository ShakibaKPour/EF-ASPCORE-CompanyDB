using Company.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string FirtName { get; set; }

    [MaxLength(50), Required]
    public string LastName { get; set; }
    [Required]
    public double Salary { get; set; }
    [Required]
    public bool HasUnion { get; set; }

    public int DepartmentId { get; set; }

    public Department? department { get; set; }

    public virtual ICollection<Title>? Titles { get; set; }
}
