using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<IEnumerable<Product>> GetByCategory(Guid id);
        Task<IEnumerable<Category>> GetCategories();

        void Create(Product product);
        void Update(Product product);

        void Create(Category category);
        void Update(Category category);
    }
}
