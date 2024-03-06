namespace Kutuphane.API.Tools
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }

        public TokenResponse(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }



    }
}
