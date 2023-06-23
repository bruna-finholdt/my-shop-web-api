using Iteris.Loja.API.Domain.Entity;

namespace Iteris.Loja.API.Domain.DTO
{
    public class CustomerCompletoResponse : CustomerResponse //ele herda os demais do CustomerResponse
    {
        public CustomerCompletoResponse(Customer customer)
            : base(customer)
        {
            City = customer.City;
            Country = customer.Country;
            Phone = customer.Phone;
        }

        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}

//Na intenção de retornar todos os detalhes na consulta de cliente por id


