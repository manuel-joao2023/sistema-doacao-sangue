using DoacaoViva.Application.Interface;
using DoacaoViva.Database;
using DoacaoViva.Domain.Entitys;

namespace DoacaoViva.Infrastructure.Microservices;
public class RequestServices : Repository<Request>, IRequest
{
    private readonly IDonator _donator;
    public RequestServices(DoacaoVivaContext doacaoVivaContext, IDonator donator) 
        : base(doacaoVivaContext)
    {
        _donator = donator;
    }

    public async Task<bool> Solicitacao(Request request) {
        var solicitacao = await Post(request);
        if (solicitacao != null) {
            await GetSendNotificationDonatorsByHospital(request);
        }
        return true;
    }

    private async Task GetSendNotificationDonatorsByHospital(Request request) {
        var erros = new List<string>();
        foreach (var item in request.Hospitals.ToList()) {
            var donators = await _donator.GetDonatorByIdHospital(item.IdHospital);
            //enviar notificação para os doaddores.
        }
    }
}

