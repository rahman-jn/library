using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class SecurityMiddleware
{
    private readonly RequestDelegate _next;
    private  static IConfiguration _configuration;

    public SecurityMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;

    }

    public async Task InvokeAsync(HttpContext context)
    {
        
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var protectedPaths = _configuration.GetSection("Routes:Protected").Get<string[]>();
        var requestMethod = context.Request.Method;
        var isProtected = (context.Request.Method == HttpMethods.Put ||
                           protectedPaths.Any(path => context.Request.Path.StartsWithSegments("/" + path)))
            ? true
            : false;


        if (token != null || (isProtected && token != null) )
        {
            try
            {
                // Validate the token
                var claimsPrincipal = ValidateToken(token);
                context.User = claimsPrincipal;
                if (!context.User.Identity.IsAuthenticated)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Login to site to access this method.");
                    return;
                }

                // Check if the request path requires admin role
                if (context.Request.Path.StartsWithSegments("/admin"))
                {
                        var roleIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == "RoleId");
                        if (roleIdClaim != null && int.TryParse(roleIdClaim.Value, out int roleId))
                        {
                            if (roleId != 2)
                            {
                                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                                await context.Response.WriteAsync("User is not authorized (Admin only)");
                                return;
                            }
                        }
                }
            }
            catch
            {
                // Token validation failed
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid token");
                return;
            }
        }
        else
        {
            // No token provided and path requires authentication
            if (context.Request.Path.StartsWithSegments("/api/admin"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("No token provided");
                return;
            }
        }

        // If everything is okay, continue processing the request
        await _next(context);
    }

    private ClaimsPrincipal ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Auth:JWT_Secret"]); // Replace with your secret key
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            // Set this to false if you don't want to validate the lifetime of the token
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

        // Validate the token is a JWT
        if (validatedToken is JwtSecurityToken jwtToken && 
            jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            return principal;
        }
        else
        {
            throw new SecurityTokenException("Invalid token");
        }
    }
}
