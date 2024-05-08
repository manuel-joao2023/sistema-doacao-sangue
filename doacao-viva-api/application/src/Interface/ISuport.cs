using DoacaoViva.Domain.Entitys;

namespace DoacaoViva.Application.Interface;
public interface ISuport : ICrudBase<Suport>
{
    Task<Suport?> GetSuportByDescription(string description);
    Task<Suport?> GetSuportByAbbreviation(string abbreviation);
    Task<IEnumerable<Suport?>> GetSuportByParent(Guid parentId);
}
