using Microsoft.AspNetCore.Identity;

namespace RosaFoods.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if(!_roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                role.NormalizedName = "MEMBER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if(_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user,"Univesp#2024").Result;

                if(result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user,"Member").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Univesp#2024").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            
            //if (_userManager.FindByEmailAsync("joser").Result == null)
            //{
            //    IdentityUser user = new IdentityUser();
            //    user.UserName = "joser";
            //    user.Email = "joser";
            //    user.NormalizedUserName = "JOSER";
            //    user.NormalizedEmail = "JOSER";
            //    user.EmailConfirmed = true;
            //    user.LockoutEnabled = false;
            //    user.SecurityStamp = Guid.NewGuid().ToString();
            
            //    IdentityResult result = _userManager.CreateAsync(user, "joser").Result;
            
            //    if (result.Succeeded)
            //    {
            //        _userManager.AddToRoleAsync(user, "Admin").Wait();
            //    }
            //}
            //if (_userManager.FindByEmailAsync("admin").Result == null)
            //{
            //    IdentityUser user = new IdentityUser();
            //    user.UserName = "admin";
            //    user.Email = "admin";
            //    user.NormalizedUserName = "ADMIN";
            //    user.NormalizedEmail = "ADMIN";
            //    user.EmailConfirmed = true;
            //    user.LockoutEnabled = false;
            //    user.SecurityStamp = Guid.NewGuid().ToString();
            
            //    IdentityResult result = _userManager.CreateAsync(user, "pi2rosaf").Result;
            
            //    if (result.Succeeded)
            //    {
            //        _userManager.AddToRoleAsync(user, "Admin").Wait();
            //    }
            //}
        }
    }
}
