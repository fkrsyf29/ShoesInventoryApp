namespace ShoeApi.Entities
{
    public class ShoeDetail
    {
        public ShoeDetail()
        {
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        public string Ukuran { get; set; }
        public string Warna { get; set; }
        public string Merk { get; set; }
        public decimal Harga { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public Shoe Shoe { get; set; }
    }
}
