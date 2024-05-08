using DoacaoViva.Application.Auth;
using DoacaoViva.Application.DTOs;
using DoacaoViva.Application.Interface;
using DoacaoViva.Database;
using DoacaoViva.Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DoacaoViva.Infrastructure.Microservices;
public class UsersServices : Repository<Users>, IUsers {
    private readonly IAuth _authsServices;
    public UsersServices(DoacaoVivaContext doacaoVivaContext, IAuth auth) 
        : base(doacaoVivaContext) {
        _authsServices = auth;
    }

    public async Task<LoginResponseDTO?> Login(LoginViewModelDTO loginReceiveDTO) {
        var user = await _doacaoVivaContext.Users.SingleOrDefaultAsync(
            u => u.EmailOrPhone == loginReceiveDTO.Username 
            && u.Password == _authsServices.GeneretaHashPassword(loginReceiveDTO.Password)
            );
        if (user is not null) {
           var token = _authsServices.GenerateJwtToken(user.EmailOrPhone, user.Role);
           return new(user.EmailOrPhone,token, user.IdPerson, user.Role);
        }
        return null;
    }
    public override async Task<List<Users>> GetAllAsync() {
        var result = await base.GetAllAsync();
        result.ForEach(u => { u.Password = string.Empty; });
        return result;
    }
    public override async Task<Users?> GetById(Guid id) {
        var user =await base.GetById(id);
        if (user != null) { user.Password = string.Empty; }
        return user;
    }
    public override async Task<Users?> Post(Users model) {
        if (!await Exist(model)) {
            model.Password = _authsServices.GeneretaHashPassword(model.Password);
           return await base.Post(model);
        }
        return new();
    }

    public override async Task<bool> Exist(Users model) {
        return (await _doacaoVivaContext.Users.Where
            (
            e=> e.EmailOrPhone ==  model.EmailOrPhone 
            && e.IdPerson == model.IdPerson
        ).FirstOrDefaultAsync()) != null;
    }
}

