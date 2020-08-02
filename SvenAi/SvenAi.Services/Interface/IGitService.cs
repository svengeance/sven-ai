using System.Threading.Tasks;
using SvenAi.Core.Git;

namespace SvenAi.Services.Interface
{
    public interface IGitService
    {
        Task<GitUserViewModel> GetUserInformation(string userName);
    }
}