using Microsoft.EntityFrameworkCore;
using ShoeApi.Data;
using ShoeApi.Entities;

namespace ShoeApi.Repositories;
public interface IShoeRepository
{
    IEnumerable<Shoe> GetAllShoe();
    Shoe GetShoeById(int id);
    Shoe CreateShoe(Shoe Shoe);
    Shoe UpdateShoe(Shoe Shoe);
    Shoe DeleteShoe(int id);
}
public class ShoeRepository : IShoeRepository
{
    private readonly DataContext _context;

    public ShoeRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Shoe> GetAllShoe()
    {
        return _context.Shoes
            .Include(s => s.ShoeDetails)
            .Include(s => s.Reviews)
            .Include(s => s.TransShoeCategories)
                .ThenInclude(sk => sk.Category)
            .ToList();
    }

    public Shoe GetShoeById(int id)
    {
        return _context.Shoes
            .Include(s => s.ShoeDetails)
            .Include(s => s.Reviews)
            .Include(s => s.TransShoeCategories)
                .ThenInclude(sk => sk.Category)
            .FirstOrDefault(s => s.Id == id);
    }

    public Shoe CreateShoe(Shoe Shoe)
    {
        _context.Shoes.Add(Shoe);
        _context.SaveChanges();

        return Shoe;
    }

    public Shoe UpdateShoe(Shoe Shoe)
    {
        _context.Shoes.Update(Shoe);
        _context.SaveChanges();

        return Shoe;
    }

    public Shoe DeleteShoe(int id)
    {
        var Shoe = _context.Shoes
            .Include(s => s.ShoeDetails)
            .Include(s => s.Reviews)
            .Include(s => s.TransShoeCategories)
            .FirstOrDefault(s => s.Id == id);

        if (Shoe != null)
        {
            Shoe.IsDeleted = true;
            Shoe.Updated = DateTime.Now;
            _context.Shoes.Update(Shoe);
            _context.SaveChanges();
        }

        return Shoe;
    }
}