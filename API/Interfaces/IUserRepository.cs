using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(APPUser user);
        Task<bool>SaveAllAsync();
        Task<IEnumerable<APPUser>>GetUsersAsync();
        Task<APPUser>GetUserByIdAsync(int id);
        Task<APPUser>GetUserByUsernameAsync(string username);
        
        Task<IEnumerable<MemberDto>>GetMembersAsync();
        Task<MemberDto>GetmemberAsync(string username);
    }
}