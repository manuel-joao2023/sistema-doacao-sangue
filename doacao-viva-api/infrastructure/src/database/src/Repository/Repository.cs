using DoacaoViva.Application;
using DoacaoViva.Database;
using DoacaoViva.Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DoacaoViva.Infrastructure.Microservices;
public abstract class Repository<T> : ICrudBase<T> where T : BaseEntity {

    protected readonly DoacaoVivaContext _doacaoVivaContext;
    protected Repository(DoacaoVivaContext doacaoVivaContext)
    {
        _doacaoVivaContext = doacaoVivaContext;
    }

    public virtual async Task<bool> Delete(T entity) {
        try {
            var result = GetById(entity.Id);
            if (result is not null) {
                _doacaoVivaContext.Remove(result);
                await _doacaoVivaContext.SaveChangesAsync();
                return true;
            }
        } catch (Exception) {

            throw;
        }
        return false;
    }

    public virtual async Task<bool> DeleteRange(T[] entityArray) {
        try {
            
            if (entityArray.Length > 0) {
                _doacaoVivaContext.RemoveRange(entityArray);
                await _doacaoVivaContext.SaveChangesAsync();
                return true;
            }
        } catch (Exception) {

            throw;
        }
        return false;
    }

    public virtual async Task<List<T>> GetAllAsync() {
       return await _doacaoVivaContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> GetById(Guid id) {
        return await _doacaoVivaContext.Set<T>().Where(x=> x.Id == id).FirstOrDefaultAsync();
    }

    public virtual async Task<T?> Post(T model) {
        await _doacaoVivaContext.AddAsync(model);
        await _doacaoVivaContext.SaveChangesAsync();
        return model;
    }

    public virtual async Task<T?> Put(Guid id, T model) {
        var result = await GetById(id);
        if (result != null) {
             result = model;
             result.Id = id;
            _doacaoVivaContext.Update(result);
            await _doacaoVivaContext.SaveChangesAsync();
        }
        return result;
    }

    public virtual async Task<bool> Exist(T model)
        => await _doacaoVivaContext
                 .Set<T>()
                 .Where(x => x.Id == model.Id)
                 .FirstOrDefaultAsync() != null;

}

