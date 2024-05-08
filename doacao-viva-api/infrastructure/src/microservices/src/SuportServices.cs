using DoacaoViva.Application.Interface;
using DoacaoViva.Database;
using DoacaoViva.Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DoacaoViva.Infrastructure.Microservices;
public class SuportServices : Repository<Suport>, ISuport
{
    public SuportServices(DoacaoVivaContext doacaoVivaContext) : base(doacaoVivaContext)
    {
    }

    public async Task<Suport?> GetSuportByAbbreviation(string abbreviation) {
        var suports = await _doacaoVivaContext.Suports.ToListAsync();
        return suports.FirstOrDefault(x => x.Abbreviation.Equals(abbreviation, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<Suport?> GetSuportByDescription(string description) {
        var suports = await _doacaoVivaContext.Suports.ToListAsync();
        return suports.FirstOrDefault(x => x.Description.Equals(description, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<Suport?>> GetSuportByParent(Guid parentId) =>
         await _doacaoVivaContext.Suports.Where(x => x.ParentId == parentId).ToListAsync();
    
}

