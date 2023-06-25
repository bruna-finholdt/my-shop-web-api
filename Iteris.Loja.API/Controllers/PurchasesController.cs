using Iteris.Loja.API.Domain.DTO;
using Iteris.Loja.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Iteris.Loja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        //usando o PurchaseService via injeção de dependência:
        private readonly PurchasesService _service;

        public PurchasesController(PurchasesService service)
        {
            _service = service;
        }

        [HttpPost]
        // FromBody para indicar que o corpo da requisição deve ser mapeado para o modelo
        public async Task<IActionResult> Post([FromBody] PurchaseCreateRequest postModel)
        {
            //Validação modelo de entrada
            if (ModelState.IsValid)
            {
                var retornoCriacao = await _service.Cadastrar(postModel);
                if (retornoCriacao.Sucesso)
                {
                    return Ok(retornoCriacao.Conteudo);
                }
                else
                {
                    return BadRequest(retornoCriacao);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        /// <summary>
        /// Lista Purchases
        /// </summary>
        /// <remarks>
        /// Se o metodo é async sempre devemos retornar uma Task
        /// </remarks>
        /// <see cref="https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/async/"/>
        /// <returns>Lista de customers</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PurchaseQueryRequest queryResquest)//Lista Purchases
                                                                                            //com paginação
        {
            //Validação modelo de entrada
            var retorno = await _service.Pesquisar(queryResquest);//é o ListarTodos (purchases)

            if (retorno.Sucesso)
                return Ok(retorno);
            else
                return BadRequest(retorno);
        }

    }
}
