// Importações necessárias para uso de anotações, herança e recursos ASP.NET
using Entities.Notifications;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Entities
{
    // Define que essa classe será mapeada para a tabela "TB_PRODUTO" no banco de dados
    [Table("TB_PRODUTO")]
    public class Produto : Notifies // Herda da classe Notifies para utilizar validações e notificações
    {
        // Define a coluna "PRD_ID" como chave primária
        [Column("PRD_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        // Define a coluna "PRD_NOME", com limite de 255 caracteres
        [Column("PRD_NOME")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("PRD_DESCRICAO")]
        [Display(Name = "Descrição")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Column("PRD_OBSERVACAO")]
        [Display(Name = "Observação")]
        [MaxLength(20000)]
        public string Observacao { get; set; }

        [Column("PRD_VALO")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Column("PRD_QTD_ESTOQUE")]
        [Display(Name = "Quantidade Estoque")]
        public int QtdEstoque { get; set; }

        // Relacionamento com o usuário que cadastrou o produto
        [Display(Name = "Usuário")]
        [ForeignKey("ApplicationUser")] // Define chave estrangeira para a entidade ApplicationUser
        [Column(Order = 1)] // Define ordem da coluna em consultas ou mapeamentos mais específicos
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } // Propriedade de navegação

        [Column("PRD_ESTADO")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Column("PRD_DATA_CADASTRO")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("PRD_DATA_ALTERACAO")]
        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }

        // Propriedades abaixo não são mapeadas para o banco de dados

        [NotMapped]
        public int IdProdutoCarrinho { get; set; } // Usado para representar o ID do produto no carrinho

        [NotMapped]
        public int QtdCompra { get; set; } // Quantidade que o usuário deseja comprar

        [NotMapped]
        public IFormFile Imagem { get; set; } // Imagem do produto enviada pelo formulário

        // URL da imagem do produto, armazenada no banco de dados
        [Column("PRD_URL")]
        public string Url { get; set; }
    }
}
