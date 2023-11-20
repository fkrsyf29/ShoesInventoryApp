using Newtonsoft.Json;
using ShoeApi.Entities;
using ShoeApi.Models;
using ShoeApi.Repositories;

namespace ShoeApi.Services
{
    public interface IShoeService
    {
        IEnumerable<Shoe> GetAllShoe();
        Shoe GetShoeById(int id);
        Shoe CreateShoe(ShoeCreationDTO shoeCreationDTO);
        Shoe UpdateShoe(int id, ShoeCreationDTO shoeCreationDTO);
        Shoe DeleteShoe(int id);
    }
    public class ShoeService : IShoeService
    {
        private readonly IShoeRepository _ShoeRepository;

        public ShoeService(IShoeRepository ShoeRepository)
        {
            _ShoeRepository = ShoeRepository;
        }

        public IEnumerable<Shoe> GetAllShoe()
        {
            return _ShoeRepository.GetAllShoe();
        }

        public Shoe GetShoeById(int id)
        {
            return _ShoeRepository.GetShoeById(id);
        }

        public Shoe CreateShoe(ShoeCreationDTO shoeCreationDTO)
        {
            var newShoe = new Shoe
            {
                Name = shoeCreationDTO.ShoeName,
                Description = shoeCreationDTO.Description,
                ShoeDetails = shoeCreationDTO.ShoeDetail,
                Reviews = shoeCreationDTO.reviewsList,
                TransShoeCategories = shoeCreationDTO.CategoryIds.Select(kId => new TransShoeCategory { CategoryId = kId }).ToList()
            };

            //string json = JsonConvert.SerializeObject(newShoe,Formatting.Indented, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});

            return _ShoeRepository.CreateShoe(newShoe);
        }

        public Shoe UpdateShoe(int id, ShoeCreationDTO shoeCreationDTO)
        {
            var existingShoe = _ShoeRepository.GetShoeById(id);

            if (existingShoe == null)
            {
                return null;
            }
            existingShoe.Name = shoeCreationDTO.ShoeName;
            existingShoe.Description = shoeCreationDTO.Description;
            existingShoe.Updated = DateTime.Now;
            existingShoe.ShoeDetails = shoeCreationDTO.ShoeDetail;
            existingShoe.ShoeDetails.Updated = DateTime.Now;
            existingShoe.Reviews = shoeCreationDTO.reviewsList;
            existingShoe.TransShoeCategories = shoeCreationDTO.CategoryIds.Select(kId => new TransShoeCategory { CategoryId = kId }).ToList();

            return _ShoeRepository.UpdateShoe(existingShoe);
        }

        public Shoe DeleteShoe(int id)
        {
            return _ShoeRepository.DeleteShoe(id);
        }
    }
}
