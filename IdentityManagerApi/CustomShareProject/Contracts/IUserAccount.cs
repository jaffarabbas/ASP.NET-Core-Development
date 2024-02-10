using CustomShareProject.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CustomShareProject.DTOS.ServiceResponces;

namespace CustomShareProject.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(UserDtos userDtos);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}
