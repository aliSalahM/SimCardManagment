using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimCardManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Initializer
{

    public static Task CreateRoles(IServiceProvider serviceProvider)
    {
        return new Initializer()._CreateRoles(serviceProvider);

    }
    private async Task _CreateRoles(IServiceProvider serviceProvider)
    {
        //adding custom roles
        RoleManager<IdentityRole> RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        UserManager<ApplicationUser> UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        string[] roleNames = { "Admin", "Manager", "User" };

        IdentityResult roleResult;

        foreach (string roleName in roleNames)
        {
            //creating the roles and seeding them to the database
            bool roleExist = await RoleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
        var pwuser = "Super@super.com";
        var pass = "Super@1234";
        var name = "ع.ص";

        var user = new ApplicationUser { UserName = pwuser, Email = pwuser ,Name = name};
        var result = await UserManager.CreateAsync(user, pass);
        if (result.Succeeded)
        {
            //if (!await UserManager.IsInRoleAsync(user, "Super"))
            //{
            //    await UserManager.AddToRoleAsync(user, "Super");

            //}
            await AssignRoleUser(UserManager, user, "Admin");

        }
        foreach (var item in result.Errors)
        {
            Console.WriteLine("Error ==> " + item);

        }
    }

    public static async Task AssignRoleUser(UserManager<ApplicationUser> UserManager, ApplicationUser user, string role)
    {

        if (!await UserManager.IsInRoleAsync(user, role))
        {
            await UserManager.AddToRoleAsync(user, role);

        }

    }

}

