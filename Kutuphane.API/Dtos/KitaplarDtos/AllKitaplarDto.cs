namespace Kutuphane.API.Dtos.KitaplarDtos
{
    public class AllKitaplarDto
    {
        public int KitapID { get; set; }
        public string KitapAd { get; set; }
        public DateTime YayinTarihi { get; set; }
        public int SayfaSayisi { get; set; }
        public int YazarID { get; set; }
        public int YayinEviID { get; set; }
        public int KategoriID { get; set; }
    }
}
