using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Business.Features.Auth.Login;
using NTierArchitecture.Entities.Models;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public LoginCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser appUser = await _userManager.Users.Where(p => p.UserName == request.UserNameorEmail || p.Email == request.UserNameorEmail).FirstOrDefaultAsync(cancellationToken);    
        
        if (appUser is null) 
        {
            throw new ArgumentNullException("kullanıcı bulunamadı");
        }

        bool checkPassword = await _userManager.CheckPasswordAsync(appUser, request.Password);
        if (checkPassword)
        {
            throw new ArgumentException("şifre yanlış");
        }

        return Unit.Value;

    
    }
}
