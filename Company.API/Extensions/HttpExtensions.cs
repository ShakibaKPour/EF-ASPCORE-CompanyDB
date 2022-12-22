namespace Company.API.Extensions;

public static class HttpExtensions
{

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db)
        where TEntity : class, IEntity
        where TDto : class
    {
        try
        {
            var entities = await db.GetAsync<TEntity, TDto>();
            return Results.Ok(entities);
        }
        catch (Exception ex) { throw; }

    }

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db, int id)
       where TEntity : class, IEntity
       where TDto : class
    {
        try
        {
            var entity = await db.SingleAsync<TEntity, TDto>(f => f.Id.Equals(id));
            if (entity == null) return Results.BadRequest();
            return Results.Ok(entity);
        }
        catch (Exception ex) { throw; }
    }

    public static async Task<IResult> HttpPostAsync<TEntity, TDto>(this IDbService db, TDto dto)
      where TEntity : class, IEntity
      where TDto : class
    {
        try
        {
            if (dto is null) return Results.BadRequest();
            var entity = await db.AddAsync<TEntity, TDto>(dto);
            if (await db.SaveChangeAsync())
            {
                var Uri = db.GetURI<TEntity>(entity);
                return Results.Created(Uri, entity);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return Results.BadRequest();
    }

    public static async Task<IResult> HttpPutAsync<TEntity, TDto>(this IDbService db, TDto dto, int id)
      where TEntity : class, IEntity
      where TDto : class
    {
        try
        {
            if (dto is null) return Results.BadRequest();
            if (!await db.AnyAsync<TEntity>(e => e.Id.Equals(id)))
                return Results.NotFound();

            db.Update<TEntity, TDto>(id, dto);

            if (await db.SaveChangeAsync())
                return Results.NoContent();
        }
        catch (Exception ex)
        {
            throw;
        }
        return Results.BadRequest();
    }

    public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id)
       where TEntity : class, IEntity
    {
        try
        {

            if (!await db.AnyAsync<TEntity>(e => e.Id.Equals(id)))
                return Results.NotFound();

            await db.DeleteAsync<TEntity>(id);

            if (await db.SaveChangeAsync())
                return Results.NoContent();

        }
        catch (Exception ex)
        {
            throw;
        }
        return Results.BadRequest();

    }

    public static async Task<IResult> HttpDeleteAsync<TReferenceEntity, TDto>(this IDbService db, TDto dto)
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class
    {
        try
        {
            if (!db.Delete<TReferenceEntity, TDto>(dto)) return Results.NotFound();
            if (await db.SaveChangeAsync())
                return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest();
        }
        return Results.BadRequest();
    }

    public static async Task<IResult> HttpAddReferenceAsync<TEntity, TDto>(this IDbService db, TDto dto)
        where TEntity : class, IReferenceEntity
        where TDto : class
    {
        try
        {
            if (dto is null) return Results.BadRequest();
            var entity = await db.AddReferenceAsync<TEntity, TDto>(dto);
            if (await db.SaveChangeAsync()) return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest();
        }
        return Results.BadRequest();

    }
}
