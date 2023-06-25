using Iteris.Loja.API.DAL.Base;
using Iteris.Loja.API.Domain.Entity;

namespace Iteris.Loja.API.DAL.Repositories
{
    public class OrderItemsRepository : BaseRepository<OrderItem>
    {
        public OrderItemsRepository(IterisLojaContext lojaContext) : base(lojaContext)
        {
        }
    }
}


//using Iteris.Loja.API.Domain.Entity;

//namespace Iteris.Loja.API.DAL.Repositories
//{
//    public class OrderItemsRepository
//    {
//        private readonly IterisLojaContext _lojaContext;

//        public OrderItemsRepository(IterisLojaContext lojaContext)
//        {
//            _lojaContext = lojaContext;
//        }

//        public async Task<List<OrderItem>> CadastrarVarios(List<OrderItem> novo)
//        {
//            _lojaContext.OrderItems.AddRange(novo);
//            await _lojaContext.SaveChangesAsync(); // Todo o Entiy está preparado para isso
//            return novo;
//        }
//    }
//}
