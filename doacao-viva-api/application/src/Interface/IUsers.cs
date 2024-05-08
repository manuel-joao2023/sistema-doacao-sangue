
using DoacaoViva.Application.DTOs;
using DoacaoViva.Domain.Entitys;

namespace DoacaoViva.Application.Interface;
public interface IUsers : ICrudBase<Users> {
    Task<LoginResponseDTO?> Login(LoginViewModelDTO loginReceive);
}

