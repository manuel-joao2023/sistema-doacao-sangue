using DoacaoViva.Application.Interface;
using DoacaoViva.Database;
using DoacaoViva.Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DoacaoViva.Infrastructure.Microservices;
public class DonatorServices : Repository<Donator>, IDonator
{
    public DonatorServices(DoacaoVivaContext doacaoVivaContext) : base(doacaoVivaContext)
    {
    }

    public async Task<IEnumerable<Donator?>> GetDonatorByAge(int age) 
        =>await _doacaoVivaContext
                .Donators
                .Include(x=>x.Person)
                .Where(d => d.Age == age)
                .ToListAsync();
    

    public async Task<IEnumerable<Donator?>> GetDonatorByHospital(HospitalRequest hospitalRequest) {
        var donatorHospital = await _doacaoVivaContext
                                    .Donators
                                    .Where(d => d.DonatorHospital
                                        .Any(dh => dh.IdHospital == hospitalRequest.IdHospital))
                                    .ToListAsync();
       
        if (donatorHospital.Count > 0) {
            return  donatorHospital
                    .Where(d => hospitalRequest.RequestBloodTypes
                        .Any(rbt => rbt.IdBloodType == d.IdBloodType))
                    .ToList();
        }
        return donatorHospital;
    }

    public async Task<IEnumerable<Donator?>> GetDonatorByIdBloobType(Guid IdBloodType) 
        => await _doacaoVivaContext
                 .Donators
                 .Include(x => x.Person)
                 .Where(x => x.IdBloodType == IdBloodType)
                 .ToListAsync();
    

    public async Task<IEnumerable<Donator?>> GetDonatorByIdHospital(Guid IdHospital) 
        =>  await _doacaoVivaContext
                  .Donators
                  .Include(x => x.Person)
                  .Where(x => x.DonatorHospital.Any(y => y.IdHospital == IdHospital))
                  .ToListAsync();
    

    public async Task<Donator?> GetDonatorByIdPerson(Guid IdPerson) 
        => await _doacaoVivaContext
                 .Donators
                 .Include(x => x.Person)
                 .FirstOrDefaultAsync(x => x.IdPerson == IdPerson);
    

   
}

