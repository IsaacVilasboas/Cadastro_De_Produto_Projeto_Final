using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    public partial class Produto
    {
        public int Id { get; set; }       

        [Required(ErrorMessage = "Digite o Código de Barra")]
        public string CodBarra { get; set; } = null!;

        [Required(ErrorMessage = "Digite o Nome do Produto")]
        public string NomeProduto { get; set; } = null!;

        [Required(ErrorMessage = "Digite o Nome do Fornecedor")]
        public string NomeFornecedor { get; set; } = null!;

        [Required(ErrorMessage = "Digite a data de cadastro")]
        [DataType(DataType.Date)]
        [Display(Name = "DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Digite o Nome da Categoria")]
        public string Categoria { get; set; } = null!;

        public decimal? Preco { get; set; }

        public int? Qtd { get; set; }      
        
        public string? Tipo { get; set; }

        public string? Sabor { get; set; }

        public string? Recipiente { get; set; }

        public string? Peso { get; set; }
        
    }
}
