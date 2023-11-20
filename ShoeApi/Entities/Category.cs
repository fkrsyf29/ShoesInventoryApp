namespace ShoeApi.Entities
{
    public class Category
    {
        public Category()
        {
            IsDeleted = false;
            Created = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public ICollection<TransShoeCategory> TransShoeCategories { get; set; }
    }
}
