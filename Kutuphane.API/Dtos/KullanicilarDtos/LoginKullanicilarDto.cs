namespace Kutuphane.API.Dtos.KullanicilarDtos
{
    public class LoginKullanicilarDto
    {
        public int? KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string? Yetki { get; set; }
    }
}
