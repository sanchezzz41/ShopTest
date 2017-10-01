using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopTest.Domain.Entities;

namespace ShopTest.Database
{
    /// <summary>
    /// Статический класс расширения
    /// </summary>
    public static class DatabaseInitializer
    {
        public static async Task Initialize(this DatabaseContext context, IServiceProvider services)
        {
            var userManager = services.GetService<UserManager<User>>();
            var roleManager = services.GetService<RoleManager<IdentityRole>>();

            //Иницилизация ролей
            {
                foreach (var roleOpt in Enum.GetValues(typeof(RolesOptions)))
                {
                    var nameRole = Enum.GetName(typeof(RolesOptions), roleOpt);
                    var resultRole = await roleManager.FindByNameAsync(nameRole);
                    if (resultRole == null)
                    {
                        resultRole = new IdentityRole(nameRole);
                        await roleManager.CreateAsync(resultRole);
                    }
                }
            }

            //Иницилизация админа
            {
                var admin = new User("admin", "admin@mail.ru", "adminnumber");
                var password = "admin";
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, nameof(RolesOptions.Admin));
                }
            }
        }
    }
}
