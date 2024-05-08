using DoacaoViva.Domain.Entitys;

namespace DoacaoViva.Application.Interface;
public interface IDonator : ICrudBase<Donator>
{
    Task<IEnumerable<Donator?>> GetDonatorByHospital(HospitalRequest hospitalRequest);
    Task<IEnumerable<Donator?>> GetDonatorByIdBloobType(Guid IdBloodType);
    Task<Donator?> GetDonatorByIdPerson(Guid IdPerson);
    Task<IEnumerable<Donator?>> GetDonatorByAge(int age);
    Task<IEnumerable<Donator?>> GetDonatorByIdHospital(Guid IdHospital);
}

