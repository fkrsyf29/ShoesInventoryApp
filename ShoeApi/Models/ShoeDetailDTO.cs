namespace ShoeApi.Models
{
    public class ShoeDetailDTO
    {
        public int ShoeId { get; set; }
        public string Ukuran { get; set; }
        public string Warna { get; set; }
        public string Merk { get; set; }
        public decimal Harga { get; set; }
    }
}
