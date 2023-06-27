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
                //product => queryResquest.ShowDiscontinuedProducts && product.IsDiscontinued (assim só mostra os produtos discontinuados)
                product => queryResquest.ShowDiscontinuedProducts || !product.IsDiscontinued,
                //product is the input parameter representing an individual product in the collection

                //queryResquest.ShowDiscontinuedProducts is the value of the ShowDiscontinuedProducts property in the ProductQueryRequest object.
                //It determines whether discontinued products should be shown (true) or not (false). São as opções do filtro

                //!product.IsDiscontinued checks if the IsDiscontinued property of the product is false, indicating that the product is active (not discontinued).

                //conclusion:
                //Se queryRequest.ShowDisconectedProducts for true (filtro setado pra true) - ele já traz todos os produtos (ativos e descontinuados),
                //nem entra no OU

                //Se queryRequest.ShowDiscontinuedProducts for false (filtro setado pra false), avalia-se o "!product.IsDiscontinued (produto ativo)"
                //sendo true, o produto ativo entra no resultado e é mostrado (apenas os ativos).

                //Se queryRequest.ShowDisconectedProducts não for especificado (filtro nem no true, nem no false), o default é false e aí acontece o mesmo que
                //no caso acima

                //nunca terá uma hipótese em que não se cai em uma das expressões (false e false) pois existem produtos ativos, de modo que a segunda expressão
                //nunca será false 
                queryResquest.PaginaAtual,
                queryResquest.Quantidade
            );
            // Conta itens do banco
            var contagem = await _productsRespository.Contagem();
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