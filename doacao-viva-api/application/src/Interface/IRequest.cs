using DoacaoViva.Domain;
using DoacaoViva.Domain.Entitys;

namespace DoacaoViva.Application.Interface;
public interface IRequest : ICrudBase<Request>
{
    Task<bool> Solicitacao( Request request);
}

