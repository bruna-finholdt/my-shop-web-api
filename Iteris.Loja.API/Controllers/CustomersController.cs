using Iteris.Loja.API.Domain.DTO;
using Iteris.Loja.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Iteris.Loja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //usando o CustomersService via injeção de dependência:
        private readonly CustomersService _customersService;

        public CustomersController(CustomersService customersService)
        {
            _customersService = customersService;
        }

        /// <summary>
        /// Lista Customers
        /// </summary>
        /// <remarks>
        /// Se o metodo é async sempre devemos retornar uma Task
        /// </remarks>
        /// <see cref="https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/async/"/>
        /// <returns>Lista de customers</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageQueryRequest filterResquest)//Lista Customers
                                                                                         //com paginação
        {
            //Validação modelo de entrada
            var retorno = await _customersService.Pesquisar(filterResquest);//é o ListarTodos (customers)

            if (retorno.Sucesso)
                return Ok(retorno);
            else
                return BadRequest(retorno);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //Validação modelo de entrada
            var retorno = await _customersService.PesquisaPorId(id);

            if (retorno.Sucesso)
                return Ok(retorno.Conteudo);
            else
                return NotFound(retorno);
        }

        [HttpPost]
        // FromBody para indicar de o corpo da requisição deve ser mapeado para o modelo
        public async Task<IActionResult> Post([FromBody] CustomerCreateRequest postModel)
        {
            //Validação modelo de entrada
            if (ModelState.IsValid)
            {
                var retorno = await _customersService.Cadastrar(postModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                else
                    return Ok(retorno.Conteudo);
            }
            else
                return BadRequest(ModelState);
        }
    }
}