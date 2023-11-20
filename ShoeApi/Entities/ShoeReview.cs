using Microsoft.AspNetCore.Http.HttpResults;

namespace ShoeApi.Entities
{
    public class ShoeReview
    {
        public ShoeReview()
        {
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
        public string Review { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
