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

