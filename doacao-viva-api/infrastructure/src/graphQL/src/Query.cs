using DoacaoViva.Application.DTOs;
using DoacaoViva.Application.Interface;
using DoacaoViva.Domain.Entitys;
using HotChocolate.Subscriptions;

namespace DoacaoViva.Infrastructure.GraphQL;

public class Query {
    public async Task<IEnumerable<Donator>> Doadores([Service] IDonator donator) => await donator.GetAllAsync();
    public async Task<IEnumerable<Request>> Solicitacoes([Service] IRequest request) => await request.GetAllAsync();
    public async Task<IEnumerable<Suport>> Suports([Service] ISuport suport) => await suport.GetAllAsync();
    //public async Task<IEnumerable<Suport>> SuportsById([Service] ISuport suport, [Service] ITopicEventSender eventSender, Guid Id) { 
    //    var suports = await suport.GetAllById(Id);
    //    await eventSender.SendAsync("Suports", suports);
    //    return suports;
    //}
    //public async Task<Suport> SuportsByName([Service] ISuport suport, [Service] ITopicEventSender eventSender, string name) { 
    //    var suports = await suport.GetSuportByName(name);
    //    await eventSender.SendAsync("Suports", suports);
    //    return suports;
    //}

}

