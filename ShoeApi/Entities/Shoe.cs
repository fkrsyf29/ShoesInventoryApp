namespace ShoeApi.Entities
{
    public class Shoe
    {
        public Shoe()
        {
            IsDeleted = false;
            Created = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        

        public ShoeDetail ShoeDetails { get; set; }
        public ICollection<ShoeReview> Reviews { get; set; }
        public ICollection<TransShoeCategory> TransShoeCategories { get; set; }
    }
}
