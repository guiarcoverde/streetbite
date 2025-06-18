using AutoMapper;
using StreetBite.Communication.Requests.CommonUser.Register;
using StreetBite.Domain.Repositories;
using StreetBite.Domain.Repositories.Users.CommonUser;

namespace StreetBite.Application.UseCases.Users.CommonUser.Register;

public class RegisterCommonUserUseCase(
    IMapper mapper, 
    ICommonUserWriteOnlyRepository commonUserWriteOnlyRepository,
    IUnitOfWork unitOfWork) : IRegisterCommonUserUseCase
{
    private readonly IMapper _mapper = mapper;
    private readonly ICommonUserWriteOnlyRepository _commonUserWriteOnlyRepository = commonUserWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    
    public async Task Execute(RequestCreateCommonUserJson requestCreateCommonUserJson)
    {
        var user = _mapper.Map<Domain.Entities.Users.CommonUser>(requestCreateCommonUserJson);
        
        await _commonUserWriteOnlyRepository.Add(user);
    }
}