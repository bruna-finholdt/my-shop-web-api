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
