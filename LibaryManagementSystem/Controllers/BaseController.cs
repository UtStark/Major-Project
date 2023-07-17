using CollegeWebsite.Models;

using DemoIntro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class BaseController : Controller
{
    
    public async Task CreateAuthenticationTicket(User user)
    {
        var key = Encoding.ASCII.GetBytes(SiteKeys.Token);
        var JWToken = new JwtSecurityToken(
        issuer: SiteKeys.WebSiteDomain,
        audience: SiteKeys.WebSiteDomain,
        claims: GetUserClaims(user),
        notBefore: new DateTimeOffset(DateTime.Now).DateTime,
        expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    );

        var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
        HttpContext.Session.SetString("JWToken", token);
    }


    private IEnumerable<Claim> GetUserClaims(User user)
    {
        List<Claim> claims = new List<Claim>();
        Claim _claim;
        _claim = new Claim(ClaimTypes.Name, user.UserName);
        claims.Add(_claim);

        _claim = new Claim("Role", user.Role);
        claims.Add(_claim);

        _claim = new Claim("Id", (user.Id).ToString());
        claims.Add(_claim);

        return claims.AsEnumerable<Claim>();
    }
}