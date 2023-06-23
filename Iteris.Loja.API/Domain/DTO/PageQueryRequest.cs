using System.ComponentModel.DataAnnotations;

namespace Iteris.Loja.API.Domain.DTO
{
    public class PageQueryRequest
    {
        // Permite a entrada de somente números positivos
        [Range(0, int.MaxValue)]
        // Caso não seja passado: o valor padrão é 0 (q é o primeiro index)
        public int PaginaAtual { get; set; }

        [Range(0, 50)]
        // Caso não seja passado: o valor padrão é 10
        public int Quantidade { get; set; } = 10;//de itens por página
    }
}

//Para paginar é necessário que o cliente passe a quantidade de itens por página e a página atual
//Podemos usar um objeto como este para especificar cada um dos parâmetros de query

