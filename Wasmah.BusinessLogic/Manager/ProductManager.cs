using System.Linq;
using System.Threading.Tasks;
using Wasmah.Context;
using Wasmah.Entities;
using Wasmah.Repository;

namespace Wasmah.BusinessLogic.Manager
{
    public class ProductManager : Repository<Product, DbContext>
    {
        public ProductManager(UnitOfWork unitOfWork) : base(unitOfWork.Context)
        {

        }

        public async override Task<Product> GetByIdAsync(object id)
        {
            return (await GetAsync(a => a.Id == (int)id)).FirstOrDefault();
        }

        public async Task<IQueryable<Product>> GetAllAsync()
        {
            return (await GetAsync());
        }

    }
}
