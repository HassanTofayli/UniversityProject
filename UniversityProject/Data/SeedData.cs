using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        string[] roleNames = { "Admin", "Instructor", "Student", "UniversityManager" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var adminEmail = "admin@gmail.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = "admin",
                Email = adminEmail,
                EmailConfirmed = true,
            };
            var createAdminUser = await userManager.CreateAsync(adminUser, "Admin.1");
            if (createAdminUser.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
                Console.WriteLine("Admin user created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create admin user: " + string.Join(", ", createAdminUser.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            Console.WriteLine("Admin user already exists.");
            // Optionally, update the existing admin user's password
            var token = await userManager.GeneratePasswordResetTokenAsync(adminUser);
            var result = await userManager.ResetPasswordAsync(adminUser, token, "Admin.1");

            if (result.Succeeded)
            {
                Console.WriteLine("Admin password updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update admin password: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
