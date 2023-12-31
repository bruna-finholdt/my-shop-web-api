﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Iteris.Loja.API.DAL.Base
{
    /// <summary>
    /// Essa classe tem o poder de realizar consultas simples em todas as tabelas
    /// </summary>
    /// <typeparam name="T">Entidade da aplicação</typeparam>
    public abstract class BaseRepository<T> where T : class //Repare que se trata de uma classe abstrata,
                                                            //portanto ainda faremos uso dos nossos repositórios concretos
    {
        //usando o IterisLojaContext via injeção de dependência:
        private readonly IterisLojaContext _lojaContext;

        public BaseRepository(IterisLojaContext context)
        {
            _lojaContext = context;
        }

        /// <summary>
        /// Consulta por id
        /// </summary>
        /// <remarks>
        /// Se o metodo é async sempre devemos retornar uma Task
        /// </remarks>
        /// <see cref="https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/async/"/>
        /// <param name="id">número inteiro do id da entidade</param>
        /// <returns>Customer do id consultado ou não encontrado</returns>
        public async Task<T?> PesquisaPorId(int id)//Para usar um método async, devemos colocar
                                                   //async na assinatura, Task<> no retorno e
                                                   //colocar o await na chamada de qualquer método
                                                   //async interno.
        {
            // select top 1 * from T where id = :id
            return await _lojaContext.Set<T>().FindAsync(id); //Para acessar a entidade usamos o método
                                                              //Set< T>() ele nos dá a possibilidade de
                                                              //acessar a tabela da entidade T, que assumirá
                                                              //o valor de cada uma das entidades 
        }

        /// <summary>
        /// Cadastra entidade enviada
        /// </summary>
        /// <param name="novo">Nova entidade</param>
        /// <returns>Entidade criada</returns>
        public async Task<T> Cadastrar(T novo)
        {
            _lojaContext.Add(novo);
            await _lojaContext.SaveChangesAsync(); // Todo o Entity está preparado para isso
            return novo;
        }

        /// <summary>
        /// Cadastra entidades enviadas
        /// </summary>
        /// <param name="novo">Novas entidades</param>
        /// <returns>Entidades criadas</returns>
        public async Task<IEnumerable<T>> CadastrarVarios(IEnumerable<T> novos)
        {
            _lojaContext.AddRange(novos);
            await _lojaContext.SaveChangesAsync(); // Todo o Entiy está preparado para isso
            return novos;
        }

        /// <summary>
        /// Realiza contagem de quantas linhas existem naquela tabela
        /// Necessário para formar paginação
        /// </summary>
        /// <returns>Quantidade de itens naquela tabela</returns>
        public async Task<int> Contagem() //Realiza contagem de quantos T existem no banco
        {
            return await _lojaContext.Set<T>().CountAsync();
        }

        /// <summary>
        /// Realiza contagem de quantas linhas existem que atendem o filtro na tabela
        /// Necessário para formar paginação
        /// </summary>
        /// <param name="filtro">
        /// Expressão Lambda que filtra a consulta de acordo com a condição booeana
        /// </param>
        /// <returns>Quantidade de itens que atendem o filtro na tabela</returns>
        public async Task<int> Contagem(Expression<Func<T, bool>> filtro)
        {
            return await _lojaContext.Set<T>().CountAsync(filtro);
        }

        /// <summary>
        /// Lista Entidade com paginação
        /// </summary>
        /// <param name="paginaAtual">Número da atual página de 0 até N</param>
        /// <param name="qtdPagina">Número de itens por página de 1 até 50</param>
        /// <returns>Lista de T com informações de paginação</returns>
        public async Task<List<T>> Pesquisar(int paginaAtual, int qtdPagina) //Lista de T com paginação
        {
            // Estou na página 4 (começando em 0), e tem 20 itens por página
            // descarto os primeiro 80, pego os próximos 20
            //(80 = 20 da pagina 0 + 20 da pagina 1 + 20 da pagina 2 + 20 da pag 3. Pego os proxs 20
            //da pag 4, a que estou!)
            int qtaPaginasAnteriores = paginaAtual * qtdPagina;

            return await _lojaContext
                .Set<T>()
                .Skip(qtaPaginasAnteriores)
                .Take(qtdPagina)
                .ToListAsync();
        }

        /// <summary>
        /// Lista itens da Entidade que atendem o filtro na tabela com paginação
        /// </summary>
        /// <param name="filtro">
        /// Expressão Lambda que filtra a consulta de acordo com a condição booeana
        /// </param>
        /// <param name="paginaAtual">Número da atual página de 0 até N</param>
        /// <param name="qtdPagina">Número de itens por página de 1 até 50</param>
        /// <returns>Lista filtrada de T com informações de paginação</returns>
        public async Task<List<T>> Pesquisar(Expression<Func<T, bool>> filtro, int paginaAtual, int qtdPagina)//Lista de T com paginação e filtros
        {
            // Estou na página 4 (começando em 0), e tem 20 itens por página
            // descarto os primeiro 80, pego os próximos 20
            //(80 = 20 da pagina 0 + 20 da pagina 1 + 20 da pagina 2 + 20 da pag 3. Pego os proxs 20
            //da pag 4, a que estou!)
            int qtaPaginasAnteriores = paginaAtual * qtdPagina;

            return await _lojaContext
                .Set<T>()
                .Where(filtro)
                .Skip(qtaPaginasAnteriores)
                .Take(qtdPagina)
                .ToListAsync();
        }
    }
}
