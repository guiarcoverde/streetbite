using AutoMapper;
using StreetBite.Communication.Requests;
using StreetBite.Domain.Entities;
using StreetBite.Domain.Repositories;
using StreetBite.Domain.Repositories.User;

namespace StreetBite.Application.UseCases.Users.CommonUser;

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
        var user = _mapper.Map<User>(requestCreateCommonUserJson);
        
        await _commonUserWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();
    }
}