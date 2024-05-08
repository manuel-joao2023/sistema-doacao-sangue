using DoacaoViva.Application.Interface;
using DoacaoViva.Database;
using DoacaoViva.Domain.Entitys;

namespace DoacaoViva.Infrastructure.Microservices;
public class CampaignServices : Repository<Campaign>, ICampaign {
    public CampaignServices(DoacaoVivaContext doacaoVivaContext) : base(doacaoVivaContext) {
    }
}

