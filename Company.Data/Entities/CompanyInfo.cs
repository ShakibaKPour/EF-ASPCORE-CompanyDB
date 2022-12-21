using Company.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities;

public class CompanyInfo : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string Name { get; set; }
    
    [Required]
    public int OrgNum { get; set; }

}
