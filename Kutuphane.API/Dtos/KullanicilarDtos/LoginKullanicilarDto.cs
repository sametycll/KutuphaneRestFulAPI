namespace Kutuphane.API.Dtos.KullanicilarDtos
{
    public class LoginKullanicilarDto
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string? Yetki { get; set; }
    }
}
