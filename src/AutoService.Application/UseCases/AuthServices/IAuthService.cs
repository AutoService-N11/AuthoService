using AutoService.Domain.Entities.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }

}
