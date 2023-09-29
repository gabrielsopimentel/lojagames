using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaGames.Model
{
    public class Produto
    {
        [Key] //primary key id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //identity(1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Console { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        [StringLength(1000)]
        public DateOnly DataLancamento { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [StringLength(1000)]
        public decimal Preco { get; set; } 

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Foto { get; set; } = string.Empty;

        public virtual Categoria? Categoria { get; set; }
    }
}
