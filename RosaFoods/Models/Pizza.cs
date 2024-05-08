using RosaFoods.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RosaFoods.Models
{
   [Table("Pizzas")]
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        [Required(ErrorMessage = "O nome da pizza deve ser informado")]
        [Display(Name = "Nome da pizza")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição da pizza deve ser informada")]
        [Display(Name = "Descrição da pizza")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O descrição detalhada da pizza deve ser informada")]
        [Display(Name = "Descrição detalhada da pizza")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada não pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço da pizza")]
        [Display(Name = "Preço")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99,ErrorMessage ="O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsPizzaFavorita { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        //Propriedades de navegação:
        public int CategoriaId { get; set; } /*Criando a chave estrangeira*/
        public virtual Categoria Categoria { get; set; } /*Definindo o relacionamento com a tabela Pizzas*/
    }
}
//public class Pizza
//    {
//        public int PizzaId { get; set; }
//        public string Nome { get; set; }
//        public string DescricaoCurta { get; set; }
//        public string DescricaoDetalhada { get; set; }
//        public decimal Preco { get; set; }
//        public string ImagemUrl { get; set; }
//        public string ImagemThumbnailUrl { get; set; }
//        public bool IsPizzaFavorita { get; set; }
//        public bool EmEstoque { get; set; }

//        public int CategoriaId { get; set; }
//        public virtual Categoria Categoria { get; set; }
//    }