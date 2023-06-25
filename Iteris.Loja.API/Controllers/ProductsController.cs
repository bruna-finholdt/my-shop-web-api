using Iteris.Loja.API.Domain.DTO;
using Iteris.Loja.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Iteris.Loja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productsService;
        public ProductsController(ProductsService produtosService)
        {
            _productsService = produtosService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductQueryRequest queryResquest)
        {
            //Validação modelo de entrada
            var retorno = await _productsService.Pesquisar(queryResquest);
            if (retorno.Sucesso)
                return Ok(retorno);
            else
                return BadRequest(retorno);
        }
    }
}
