using DoacaoViva.Application.DTOs;
using DoacaoViva.Application.Interface;
using DoacaoViva.Domain.Entitys;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace DoacaoViva.Infrastructure.GraphQL;
public class Mutation {

    public async Task<Donator?> CreateDonator([Service] IDonator donator, [Service] ITopicEventSender eventSender, Donator entry) {
        var newDonator = await donator.Post(entry);
        await eventSender.SendAsync("DonatorSucess", newDonator);
        return newDonator;
    }

    public async Task<Request?> CreateRequest([Service] IRequest request, [Service] ITopicEventSender eventSender, Request request_) {
        var newRequest = await request.Post(request_);
        await eventSender.SendAsync("RequestSucess", newRequest);
        return newRequest;
    }

    public async Task<LoginResponseDTO?> Logins([Service] IUsers users, [Service] ITopicEventSender eventSender, LoginViewModelDTO login) {
        var user = await users.Login(login);
        await eventSender.SendAsync("User", user);
        return user;
    }
}

