using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArchitecture.Business.Features.Auth.Register;
using NTierArchitecture.Entities.Models;

internal sealed class RegisterCommandHanler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHanler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUserNameExist = await _userManager.FindByNameAsync(request.UserName);
        if(checkUserNameExist is not null)
        {
            throw new ArgumentException("kullancı adı mevcut");
        }
        var checkEmailExist=await _userManager.FindByEmailAsync(request.Email);
        if(checkEmailExist is not null)
        {
            throw new ArgumentException("mail adresi mevcut");
        }

        AppUser appUser = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name,
            LastName = request.Lastname,
            UserName = request.UserName

        };

        await _userManager.CreateAsync(appUser, request.Password);

        return Unit.Value;
    }
}