using AutoMapper;
using Company.Data.Context;
using Company.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Company.Data.Services;

public class DbService : IDbService
{
    private readonly CompanyContext _db;
    private readonly IMapper _mapper;

    public DbService(CompanyContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<TDto>> GetAsync<TEntity, TDto>()
    where TEntity : class, IEntity
    where TDto : class
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        var dtos = _mapper.Map<List<TDto>>(entities);
        return dtos;
    }

    private async Task<TEntity?> SingleAsync<TEntity>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity =>
        await _db.Set<TEntity>().SingleOrDefaultAsync(expression);

    public async Task<TDto> SingleAsync<TEntity, TDto>(
        Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity = await SingleAsync(expression);
        var dtos = _mapper.Map<TDto>(entity);
        return dtos;
    }


    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> SaveChangeAsync() =>
        await _db.SaveChangesAsync() >= 0;

    public string GetURI<TEntity>(TEntity entity)
        where TEntity : class, IEntity
    {
        return $"/{typeof(TEntity).Name.ToLower()}s/{entity.Id}";
    }

    public void Update<TEntity, TDto>(int id, TDto dto)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.Id = id;
        _db.Set<TEntity>().Update(entity);
    }

    public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
    {
        return await _db.Set<TEntity>().AnyAsync(expression);
    }

    public async Task<bool> DeleteAsync<TEntity>(int id)
        where TEntity : class, IEntity
    {
        try
        {
            var entity = await SingleAsync<TEntity>(e => e.Id.Equals(id));
            if (entity is null) return false;
            _db.Remove(entity);
        }
        catch (Exception ex)
        {
            throw;
        }
        return true;
    }

    public bool Delete<TReferenceEntity, TDto>(TDto dto)
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class
    {
        try
        {
            var entity = _mapper.Map<TReferenceEntity>(dto);
            if (entity is null) return false;
            _db.Remove(entity);
        }
        catch (Exception ex) { throw; }

        return true;
    }

    public async Task<TEntity> AddReferenceAsync<TEntity, TDto>(TDto dto)
        where TEntity : class, IReferenceEntity
        where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }
}

