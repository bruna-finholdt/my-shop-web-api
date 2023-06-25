using Iteris.Loja.API.DAL.Repositories;
using Iteris.Loja.API.Domain.DTO;
using Iteris.Loja.API.Services.Base;
namespace Iteris.Loja.API.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository _productsRespository;
        public ProductsService(ProductsRepository productsRepository)
        {
            _productsRespository = productsRepository;
        }
        public async Task<ServicePagedResponse<ProductResponse>> Pesquisar(ProductQueryRequest queryResquest)
        {
            // Consulta itens no banco
            var listaPesquisa = await _productsRespository.Pesquisar(
                product => !queryResquest.ShowDiscontinuedProducts && !product.IsDiscontinued,
                queryResquest.PaginaAtual,
                queryResquest.Quantidade
            );
            // Conta itens do banco
            var contagem = await _productsRespository.Contagem(
                product => !queryResquest.ShowDiscontinuedProducts && !product.IsDiscontinued
            );
            // Transforma Customer em CustomerResponse
            var listaConvertida = listaPesquisa
                .Select(order => new ProductResponse(order));
            // Cria resultado com paginação
            return new ServicePagedResponse<ProductResponse>(
                listaConvertida,
                contagem,
                queryResquest.PaginaAtual,
                queryResquest.Quantidade
            );
        }
    }
}