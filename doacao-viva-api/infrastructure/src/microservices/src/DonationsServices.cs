using DoacaoViva.Application.Interface;
using DoacaoViva.Database;
using DoacaoViva.Domain.Entitys;

namespace DoacaoViva.Infrastructure.Microservices;
public class DonationsServices : Repository<Donations>, IDonations
{
    public DonationsServices(DoacaoVivaContext doacaoVivaContext) : base(doacaoVivaContext)
    {
    }
}

