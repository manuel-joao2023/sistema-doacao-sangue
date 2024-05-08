using DoacaoViva.Domain.Entitys;

namespace DoacaoViva.Application;
public interface ICrudBase<T> where T : BaseEntity {

    Task<bool> Delete(T entity);

    Task<bool> DeleteRange(T[] entityArray);

    Task<List<T>> GetAllAsync();

    Task<T?> GetById(Guid id);

    Task<T?> Post(T model);

    Task<T?> Put(Guid id, T model);

}
