using LinkedIn.API.Models;
using Sparkle.LinkedInNET;
using Sparkle.LinkedInNET.OAuth2;

namespace LinkedIn.API.Clients;

public class HttpLinkedInClient
{
    private readonly LinkedInApiConfiguration _config;
    private readonly LinkedInApi _api;
    private readonly AuthorizationScope _scope;
    private readonly string _redirectUrl = "http://127.0.0.1:5500/LinkedIn.App/Index.html";

    public HttpLinkedInClient()
    {
        _config = new("77jpp34cjc9nhk", "sf5V830O4sFPteL3");
        _api = new(_config);
        _scope = AuthorizationScope.ReadEmailAddress | AuthorizationScope.ReadLiteProfile;
    }

    public Uri GetAuthorizationUrl()
    {
        var state = Guid.NewGuid().ToString();
        return _api.OAuth2.GetAuthorizationUrl(_scope, state, _redirectUrl);
    }

    public async Task<TokenInfo> GetTokensAsync(string code)
    {
        AuthorizationAccessToken userToken = await _api.OAuth2.GetAccessTokenAsync(code, _redirectUrl);
        return new TokenInfo()
        {
            AccessToken = userToken.AccessToken,
            ExpireIn = (int)userToken.ExpiresIn
        };
    }

}

// https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=77jpp34cjc9nhk&redirect_uri=https://localhost:7256/api/auth/linkedin/callback&state=foobar&scope=r_liteprofile%20r_emailaddress%20w_member_social

// https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=77jpp34cjc9nhk&scope=r_basicprofile%20r_emailaddress&redirect_uri=https://localhost:7256/api/auth/linkedin/callback