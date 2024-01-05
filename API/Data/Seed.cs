using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<APPUser> userManager, RoleManager<APPRole> roleManager)
        {
            if(await userManager.Users.AnyAsync())return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive=true};

            var users = JsonSerializer.Deserialize<List<APPUser>>(userData);

            var roles = new List<APPRole>
            {
                new APPRole{Name = "Member"},
                new APPRole{Name = "Admin"},
                new APPRole{Name = "Moderator"},
            };

            foreach(var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach(var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new APPUser
            {
                UserName = "Admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
            
        }
        
    }
}