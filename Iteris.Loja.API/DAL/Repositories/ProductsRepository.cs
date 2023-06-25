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



//using Iteris.Loja.API.Domain.Entity;

//namespace Iteris.Loja.API.DAL.Repositories
//{
//    public class ProductsRepository
//    {
//        private readonly IterisLojaContext _lojaContext;

//        public ProductsRepository(IterisLojaContext lojaContext)
//        {
//            _lojaContext = lojaContext;
//        }

//        //Async é a forma de usar programação assincrona
//        //Isso otimiza o uso do processador
//        public async Task<Product?> PesquisaPorId(int id)
//        {
//            // select top 1 * from Customers
//            return await _lojaContext.Products.FindAsync(id);
//        }
//    }
//}