using GloboTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace GloboTicket.TicketManagement.Identity.Seed;

public static class CreateFirstUser
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
    {
        var applicationUser = new ApplicationUser
        {
            FirstName = "Brook",
            LastName = "Ayalew",
            UserName = "BrookBeck",
            Email = "brookbeck2@gmail.com",
            EmailConfirmed = true
        };

        var user = await userManager.FindByEmailAsync(applicationUser.Email);

        if(user is null)
        {
            await userManager.CreateAsync(applicationUser, "P@$$w0rd");
        }
    }
}
