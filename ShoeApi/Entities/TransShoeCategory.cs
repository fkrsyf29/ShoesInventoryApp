namespace ShoeApi.Entities
{
    public class TransShoeCategory
    {
        public TransShoeCategory()
        {
            IsDeleted = false;
            Created = DateTime.Now;
        }
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
