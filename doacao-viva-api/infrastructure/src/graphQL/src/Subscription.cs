using DoacaoViva.Domain.Entitys;
using HotChocolate.Subscriptions;
using HotChocolate.Execution;
using DoacaoViva.Application.DTOs;

namespace DoacaoViva.Infrastructure.GraphQL;
public class Subscription {

    public async ValueTask<ISourceStream<Donator?>> OnCreateDonator([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken) 
        => await eventReceiver.SubscribeAsync<Donator>("DonatorSucess", cancellationToken);
    public async ValueTask<ISourceStream<Request?>> OnCreateRequest([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken) 
        => await eventReceiver.SubscribeAsync<Request>("RequestSucess", cancellationToken);
    public async ValueTask<ISourceStream<LoginResponseDTO?>> OnLogin([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken) 
        => await eventReceiver.SubscribeAsync<LoginResponseDTO>("User", cancellationToken);
}

