using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Auth.Login
{
    public sealed record LoginCommand(string UserNameorEmail,string Password):IRequest<Unit>;
    
}
