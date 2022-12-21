using Microsoft.EntityFrameworkCore;
using Company.Data.Entities;

namespace Company.Data.Context;

public class CompanyContext : DbContext
{
    public DbSet<CompanyInfo> CompanyInfos => Set<CompanyInfo>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees=> Set<Employee>();

    public DbSet<Title> Titles => Set<Title>();

    public DbSet<EmployeeTitle> EmployeeTitles=> Set<EmployeeTitle>();

    public CompanyContext(DbContextOptions<CompanyContext> options)
    :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EmployeeTitle>().HasKey(et => new { et.EmployeeId, et.TitleId });

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var CompanyInfos = new List<CompanyInfo>()
        {
            new CompanyInfo{ Id = 1, Name= "Nordic Hair Sweden", OrgNum= 55656667},
            new CompanyInfo{ Id = 2, Name= "Nordic Hair Norway", OrgNum= 65757777}

        };
        modelBuilder.Entity<CompanyInfo>().HasData(CompanyInfos);

        var Departments = new List<Department>()
        {
            new Department{ Id = 1, Name="Administration-SE", CompanyId=1},
            new Department{ Id = 2, Name="Finance-SE", CompanyId=1},
            new Department{ Id = 3, Name="Marketing-No", CompanyId=2},
            new Department{ Id = 4, Name="Purchase-No", CompanyId=2},
            new Department{ Id = 5, Name="Logistik-SE", CompanyId=1},
            new Department {Id=6, Name="IT-SE", CompanyId=1},
            new Department{ Id = 7, Name="Production-SE", CompanyId=1}

        };
        modelBuilder.Entity<Department>().HasData(Departments);

        var Employees = new List<Employee>()
        {
            new Employee { Id = 1, DepartmentId = 1, FirtName = "Jon", LastName = "Doe", HasUnion = true, Salary = 40000 },
            new Employee { Id = 2, DepartmentId = 2, FirtName = "Sara", LastName = "Smith", HasUnion = true, Salary = 45000 },
            new Employee { Id = 3, DepartmentId = 2, FirtName = "Alex", LastName = "Larssen", HasUnion = true, Salary = 45000 },
            new Employee { Id = 4, DepartmentId = 3, FirtName = "Fredrik", LastName = "Nilsson", HasUnion = true, Salary = 50000 },
            new Employee { Id = 5, DepartmentId = 4, FirtName = "Eva", LastName = "Olsson", HasUnion = true, Salary = 47000 },
            new Employee { Id = 6, DepartmentId = 5, FirtName = "Isac", LastName = "Freja", HasUnion = true, Salary = 38000 },
            new Employee { Id = 7, DepartmentId = 6, FirtName = "Jonas", LastName = "Axelsson", HasUnion = true, Salary = 48000 },
            new Employee { Id = 8, DepartmentId = 7, FirtName = "David", LastName = "Adams", HasUnion = true, Salary = 39000 }

        };
        modelBuilder.Entity<Employee>().HasData(Employees);

        var Titles = new List<Title>()
        {
            new Title{ Id = 1, TitleName= "Teamlead"},
            new Title{ Id = 2,TitleName="Service Desk"},
            new Title{ Id = 3, TitleName="Head Of Department"},
            new Title{ Id = 4, TitleName="CIO"},
            new Title{ Id = 5, TitleName="CEO"},
            new Title{ Id = 6, TitleName="Manager"},
            new Title{ Id = 7, TitleName="Communicator"},
            new Title{ Id = 8, TitleName = "HR"}
        };
        modelBuilder.Entity<Title>().HasData(Titles);

        var EmployeeTitles = new List<EmployeeTitle>()
        {
            new EmployeeTitle{ EmployeeId=1, TitleId=3},
            new EmployeeTitle{ EmployeeId=2, TitleId=4},
            new EmployeeTitle{ EmployeeId=3, TitleId=5},
            new EmployeeTitle{ EmployeeId=4, TitleId=2},
            new EmployeeTitle{ EmployeeId=5, TitleId=1},
            new EmployeeTitle{ EmployeeId=6, TitleId=8},
            new EmployeeTitle{ EmployeeId=6, TitleId=7},
            new EmployeeTitle{ EmployeeId=8, TitleId=3},
        };
        modelBuilder.Entity<EmployeeTitle>().HasData(EmployeeTitles);

    }
}