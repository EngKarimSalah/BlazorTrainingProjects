using Microsoft.EntityFrameworkCore;
using MiniAmazonSimulation.Data.Model;
using MiniAmazonSimulation.Data.Repositories;

namespace MiniAmazonSimulation.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepo.GetAll();
        }
    }
}
