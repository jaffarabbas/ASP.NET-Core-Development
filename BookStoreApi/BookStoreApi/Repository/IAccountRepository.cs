using BookStoreApi.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreApi.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
