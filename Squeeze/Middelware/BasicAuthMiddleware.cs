using System.Net.Http.Headers;
using System.Text;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string authorizationHeader = context.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authorizationHeader))
        {
            var authHeader = AuthenticationHeaderValue.Parse(authorizationHeader);
            if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase))
            {
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials.Length > 1 ? credentials[1] : string.Empty;

                // Implementer din egen logikk for å validere brukernavn og passord
                if (username == "admin" && password == "password") // Eksempel, ikke bruk i produksjon
                {
                    // Autentisering vellykket
                    var claims = new[] { new System.Security.Claims.Claim("name", username) };
                    var identity = new System.Security.Claims.ClaimsIdentity(claims, "Basic");
                    context.User = new System.Security.Claims.ClaimsPrincipal(identity);
                    await _next(context);
                    return;
                }
            }
        }

        // Autentisering mislykket eller ingen Authorization-header
        context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"MyApp\", charset=\"UTF-8\"";
        context.Response.StatusCode = 401; // Unauthorized
        await context.Response.WriteAsync("Unauthorized. Please provide valid credentials.");
    }
}