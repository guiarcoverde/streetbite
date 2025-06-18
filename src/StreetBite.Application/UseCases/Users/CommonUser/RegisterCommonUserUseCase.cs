using AutoMapper;
using StreetBite.Communication.Requests;
using StreetBite.Domain.Repositories;
using StreetBite.Domain.Repositories.Security;
using StreetBite.Domain.Repositories.Users.CommonUser;

namespace StreetBite.Application.UseCases.Users.CommonUser;

public class RegisterCommonUserUseCase(
    IMapper mapper, 
    ICommonUserWriteOnlyRepository commonUserWriteOnlyRepository,
    IPasswordEncrypt passwordEncrypt,
    IUnitOfWork unitOfWork) : IRegisterCommonUserUseCase
{
    private readonly IMapper _mapper = mapper;
    private readonly ICommonUserWriteOnlyRepository _commonUserWriteOnlyRepository = commonUserWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IPasswordEncrypt _passwordEncrypt = passwordEncrypt;
    
    public async Task Execute(RequestCreateCommonUserJson requestCreateCommonUserJson)
    {
        var user = _mapper.Map<Domain.Entities.Users.CommonUser>(requestCreateCommonUserJson);
        
        user.Password = _passwordEncrypt.Encrypt(user.Password);
        
        await _commonUserWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();
    }
}