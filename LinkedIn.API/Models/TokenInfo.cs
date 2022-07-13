namespace LinkedIn.API.Models;

public class TokenInfo
{
    public string AccessToken { get; set; }
    
    public int ExpireIn { get; set; }
}