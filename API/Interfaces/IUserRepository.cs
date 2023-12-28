using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(APPUser user);
        Task<bool>SaveAllAsync();
        Task<IEnumerable<APPUser>>GetUsersAsync();
        Task<APPUser>GetUserByIdAsync(int id);
        Task<APPUser>GetUserByUsernameAsync(string username);
        
        Task<PagedList<MemberDto>>GetMembersAsync(UserParams userParams);
        Task<MemberDto>GetmemberAsync(string username);
    }
}