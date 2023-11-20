using ShoeApi.Entities;

namespace ShoeApi.Models
{
    public class ShoeCreationDTO
    {
        public string ShoeName { get; set; }
        public string Description { get; set; }
        public ShoeDetail ShoeDetail { get; set; }
        public List<ShoeReview> reviewsList { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
