using Iteris.Loja.API.DAL.Base;
using Iteris.Loja.API.Domain.Entity;

namespace Iteris.Loja.API.DAL.Repositories
{
    public class ProductsRepository : BaseRepository<Product>
    {
        public ProductsRepository(IterisLojaContext lojaContext) : base(lojaContext)
        {
        }
    }
}
