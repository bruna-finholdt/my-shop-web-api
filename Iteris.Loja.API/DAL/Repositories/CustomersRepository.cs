using Iteris.Loja.API.DAL.Base;
using Iteris.Loja.API.Domain.Entity;

namespace Iteris.Loja.API.DAL.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>
    {
        public CustomersRepository(IterisLojaContext lojaContext) : base(lojaContext)
        {
        }
    }
}