using Iteris.Loja.API.DAL.Repositories;
using Iteris.Loja.API.Domain.DTO;
using Iteris.Loja.API.Domain.Entity;
using Iteris.Loja.API.Services.Base;

namespace Iteris.Loja.API.Services
{
    public class CustomersService
    {
        //usando o CustomersRepository via injeção de dependência:
        private readonly CustomersRepository _customersRepository;

        public CustomersService(CustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        // Abaixo: Documentação de métodos no C#
        /// <summary>
        /// Consulta customer completo por id
        /// </summary>
        /// <remarks>
        /// Se o metodo é async sempre devemos retornar uma Task
        /// </remarks>
        /// <see cref="https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/async/"/>
        /// <param name="id">número inteiro do id do customer</param>
        /// <returns>Customer do id consultado ou não encontrado</returns>
        public async Task<ServiceResponse<CustomerCompletoResponse>> PesquisaPorId(int id)
        //Para usar um método async, devemos colocar async na assinatura, Task<> no retorno e colocar o
        //await na chamada de qualquer método async interno.
        {
            var customer = await _customersRepository.PesquisaPorId(id);
            if (customer == null)
            {
                return new ServiceResponse<CustomerCompletoResponse>(
                    "Não encontrado"
                );
            }
            return new ServiceResponse<CustomerCompletoResponse>(
                new CustomerCompletoResponse(customer)
            );
            //pra pesquisa de customer por id, usa-se o CustomerCompletoResponse (com tds as informações)
        }

        /// <summary>
        /// Cadastra customer enviado
        /// </summary>
        /// <param name="novo">Novo customer</param>
        /// <returns>Customer criado</returns>
        public async Task<ServiceResponse<CustomerResponse>> Cadastrar(CustomerCreateRequest novo)
        {
            var modeloDb = new Customer()
            {
                FirstName = novo.FirstName,
                LastName = novo.LastName,
                City = novo.City,
                Country = novo.Country,
                Phone = novo.Phone
            };

            await _customersRepository.Cadastrar(modeloDb);

            return new ServiceResponse<CustomerResponse>(new CustomerResponse(modeloDb));
        }

        /// <summary>
        /// Lista Customers com paginação
        /// </summary>
        /// <param name="paginaAtual">Número da atual página de 0 até N</param>
        /// <param name="qtdPagina">Número de itens por página de 1 até 50</param>
        /// <returns>Lista de customers com informações de paginação</returns>
        public async Task<ServicePagedResponse<CustomerResponse>> Pesquisar(PageQueryRequest queryResquest)
        //Lista Customers com paginação
        {
            // Consulta itens no banco
            var listaPesquisa = await _customersRepository.Pesquisar(
                queryResquest.PaginaAtual,
                queryResquest.Quantidade
            );
            // Conta itens do banco
            var contagem = await _customersRepository.Contagem();
            // Transforma Customer em CustomerResponse
            var listaConvertida = listaPesquisa
                .Select(customer => new CustomerResponse(customer));

            // Cria resultado com paginação
            return new ServicePagedResponse<CustomerResponse>(
                listaConvertida,
                contagem,
                queryResquest.PaginaAtual,
                queryResquest.Quantidade
            );
        }
        //No método de listagem de todos os customers, os usos do método Select da biblioteca Linq
        //funcionam como um transformador para cada objeto da lista;
    }
}