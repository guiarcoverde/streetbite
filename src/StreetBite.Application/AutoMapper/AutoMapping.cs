using AutoMapper;
using StreetBite.Communication.Requests;
using StreetBite.Domain.Entities;

namespace StreetBite.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestCreateUserJson, User>();
    }
}