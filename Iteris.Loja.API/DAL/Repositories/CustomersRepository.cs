using Iteris.Loja.API.DAL.Base;
using Iteris.Loja.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Iteris.Loja.API.DAL.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>
    {
        public CustomersRepository(IterisLojaContext lojaContext) : base(lojaContext)
        {
        }
    }
}


//using Iteris.Loja.API.Domain.Entity;
//using Microsoft.EntityFrameworkCore;

//namespace Iteris.Loja.API.DAL.Repositories
//{
//    public class CustomersRepository
//    {
//        private readonly IterisLojaContext _lojaContext;

//        public CustomersRepository(IterisLojaContext lojaContext)
//        {
//            _lojaContext = lojaContext;
//        }

//        // Abaixo: Documentação de métodos no C#
//        /// <summary>
//        /// Consulta customer por id
//        /// </summary>
//        /// <remarks>
//        /// Se o metodo é async sempre devemos retornar uma Task
//        /// </remarks>
//        /// <see cref="https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/async/"/>
//        /// <param name="id">número inteiro do id do customer</param>
//        /// <returns>Customer do id consultado ou não encontrado</returns>
//        public async Task<Customer?> PesquisaPorId(int id)
//        {
//            // select top 1 * from Customers where id = :id
//            return await _lojaContext.Customers.FindAsync(id);
//        }

//        /// <summary>
//        /// Cadastra customer enviado
//        /// </summary>
//        /// <param name="novo">Novo customer</param>
//        /// <returns>Customer criado</returns>
//        public async Task<Customer> Cadastrar(Customer novo)
//        {
//            _lojaContext.Customers.Add(novo);
//            await _lojaContext.SaveChangesAsync(); // Todo o Entiy está preparado para isso
//            return novo;
//        }

//        /// <summary>
//        /// Realiza contagem de quantos customers existem no banco
//        /// Necessário para formar paginação
//        /// </summary>
//        /// <param name="id">Número do id pesquisado</param>
//        /// <returns>Customer do id</returns>
//        public async Task<int> Contagem()
//        {
//            return await _lojaContext.Customers.CountAsync();
//        }

//        /// <summary>
//        /// Lista Customers com paginação
//        /// </summary>
//        /// <param name="paginaAtual">Número da atual página de 0 até N</param>
//        /// <param name="qtdPagina">Número de itens por página de 1 até 50</param>
//        /// <returns>Lista de customers com informações de paginação</returns>
//        public async Task<List<Customer>> Pesquisar(int paginaAtual, int qtdPagina)
//        {
//            // Estou na página 4 (começando em 0), e tem 20 itens por página
//            // descarto os primeiro 80, pego os próximos 20
//            int qtaPaginasAnteriores = paginaAtual * qtdPagina;

//            return await _lojaContext.Customers.Skip(qtaPaginasAnteriores).Take(qtdPagina).ToListAsync();
//        }
//    }
//}
