
using Microsoft.EntityFrameworkCore;
using Company.Common.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CompanyContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CompanyConnection")));

ConfigureAutoMapper(builder.Services);
ConfigureDbServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureAutoMapper(IServiceCollection services)
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<CompanyInfo, CompanyInfoDTO>().ReverseMap();
        cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
        cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
        cfg.CreateMap<Title, TitleDTO>().ReverseMap();
        cfg.CreateMap<EmployeeTitle, EmployeeTitleDTO>().ReverseMap();
    });
    var mapper =config.CreateMapper();
    services.AddSingleton(mapper);
}

void ConfigureDbServices(IServiceCollection services)
{
    services.AddScoped<IDbService, DbService>();
}
