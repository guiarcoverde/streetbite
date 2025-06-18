using Microsoft.Extensions.DependencyInjection;
using StreetBite.Application.AutoMapper;
using StreetBite.Application.UseCases.Users.CommonUser;
using StreetBite.Application.UseCases.Users.CommonUser.Login;
using StreetBite.Application.UseCases.Users.CommonUser.Register;

namespace StreetBite.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterCommonUserUseCase, RegisterCommonUserUseCase>();
        services.AddScoped<ICommonUserLoginUseCase, CommonUserLoginUseCase>();
    }
}