﻿using System.ComponentModel.DataAnnotations;

namespace Iteris.Loja.API.Domain.DTO
{
    public class CustomerCreateRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(40, ErrorMessage = "Tamanho máximo de caracteres no nome deve ser 40")]
        // StringLength: Estabelece o tamanho máximo da string
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(40)]
        public string LastName { get; set; } = null!;

        [StringLength(20)]
        public string? City { get; set; }

        [StringLength(20)]
        public string? Country { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }
    }
}
