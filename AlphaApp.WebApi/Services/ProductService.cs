using AlphaApp.DataClasses;
using AlphaApp.DataRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaApp.WebApi.Services
{
    public interface IService<TResource>
    {
        Task<int> Add(TResource resource);
        Task<int> Update(TResource resource);
        Task Delete(int id);
        Task<TResource> GetById(int id);
        Task<IList<TResource>> GetAll();
    }

    public class ProductService : IService<Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(Product resource)
        {
            return await _unitOfWork.Products.AddAsync(resource);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<int> Update(Product resource)
        {
            return await _unitOfWork.Products.UpdateAsync(resource);
        }
    }
}
