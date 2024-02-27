namespace Kutuphane.API.Dtos.KitaplarDtos
{
    public class AllKitaplarWithParametersDto
    {
        public int KitapID { get; set; }
        public string KitapAd { get; set; }
        public DateTime YayinTarihi { get; set; }
        public int SayfaSayisi { get; set; }
        public string KategoriAdi { get; set; }

        public string YazarAdSoyad { get; set; }
        public string YayinEviAdi { get; set; }
    }
}
