using Iteris.Loja.API.DAL.Base;
using Iteris.Loja.API.Domain.Entity;

namespace Iteris.Loja.API.DAL.Repositories
{
    public class OrdersRepository : BaseRepository<Order>
    {
        public OrdersRepository(IterisLojaContext lojaContext) : base(lojaContext)
        {
        }
    }
}


//using Iteris.Loja.API.Domain.Entity;

//namespace Iteris.Loja.API.DAL.Repositories
//{
//    public class OrdersRepository
//    {
//        private readonly IterisLojaContext _lojaContext;

//        public OrdersRepository(IterisLojaContext lojaContext)
//        {
//            _lojaContext = lojaContext;
//        }

//        public async Task<Order> Cadastrar(Order novo)
//        {
//            _lojaContext.Orders.Add(novo);
//            await _lojaContext.SaveChangesAsync(); // Todo o Entiy está preparado para isso
//            return novo;
//        }
//    }
//}

