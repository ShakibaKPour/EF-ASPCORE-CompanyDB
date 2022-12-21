using Company.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities;

public class Title : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string TitleName { get; set; }

    public virtual ICollection<Employee>? Employees { get; set; } 

}
