using FinalBackEndEduHome.Constants;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.DAL
{
    public class DataInitializer
    {
        private readonly AppDbContext _dbContext;
        private RoleManager<IdentityRole> _roleManager;

        public DataInitializer(AppDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            if (!_dbContext.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole(RoleConstant.User));
                await _roleManager.CreateAsync(new IdentityRole(RoleConstant.Moderator));
                await _roleManager.CreateAsync(new IdentityRole(RoleConstant.Admin));
            }
        }
    }
}
