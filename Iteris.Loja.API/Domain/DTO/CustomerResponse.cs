using Iteris.Loja.API.Domain.Entity;

namespace Iteris.Loja.API.Domain.DTO
{
    public class CustomerResponse
    {
        public CustomerResponse(Customer baseModel)
        {
            Id = baseModel.Id;
            FirstName = baseModel.FirstName;
            LastName = baseModel.LastName;
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
