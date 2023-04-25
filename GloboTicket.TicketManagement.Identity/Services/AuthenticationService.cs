using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using GloboTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Identity.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSettings _jwtSettings;

    public AuthenticationService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
    {
        var user  = await _userManager.FindByEmailAsync(request.Email);
        if(user is null)
        {
            throw new Exception($"User with {request.Email} not found.");
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName,request.Password, false, lockoutOnFailure: false);
        if(!result.Succeeded)
        {
            throw new Exception($"Credentials for '{request.Email}' aren't valid.");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
        AuthenticationResponse response = new()
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            UserName = user.UserName,
        };

        return response;
    }

    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
    {
        var existingUser = await _userManager.FindByNameAsync(request.UserName);

        if(existingUser is not null)
        {
            throw new Exception($"Username '{request.UserName}' already exist.");
        }

        ApplicationUser user = new()
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            EmailConfirmed = true
        };

        var existingEmail = await _userManager.FindByEmailAsync(user.Email);

        if(existingEmail is not null)
        {
            throw new Exception($"Email '{request.Email}' already exist");
        }

        var result = await _userManager.CreateAsync(user, request.Password);

        if(!result.Succeeded) 
        {
            throw new Exception($"{result.Errors}");
        }

        return new RegistrationResponse()
        {
            UserId = user.Id
        };
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var rolesClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            rolesClaims.Add(new Claim("roles", roles[i]));
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
        .Union(userClaims)
        .Union(rolesClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials);

        return token;
    }
}
