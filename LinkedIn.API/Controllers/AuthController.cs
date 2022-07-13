using LinkedIn.API.Clients;
using LinkedIn.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkedIn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly HttpLinkedInClient _client;

    public AuthController(HttpLinkedInClient client)
    {
        _client = client;
    }

    [HttpGet("redirect")]
    public IActionResult Get()
    {
        var url = _client.GetAuthorizationUrl();
        return Ok(url.AbsoluteUri);
    }

    [HttpGet("linkedin/callback")]
    public IActionResult Get(string code, string state)
    {
        return Ok(code + " " + state);
    }

    [HttpGet("token")]
    public async Task<IActionResult> GetToken(string code)
    {
        TokenInfo token = await _client.GetTokensAsync(code);
        return Ok(token);
    }
}