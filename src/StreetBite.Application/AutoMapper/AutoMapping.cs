using AutoMapper;
using StreetBite.Communication.Requests;
using StreetBite.Communication.Requests.CommonUser.Register;
using StreetBite.Domain.Entities;
using StreetBite.Domain.Entities.Users;

namespace StreetBite.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestCreateCommonUserJson, CommonUser>();
    }
}