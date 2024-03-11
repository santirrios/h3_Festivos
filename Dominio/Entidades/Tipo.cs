using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Tipo")]
    public class Tipo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo"), StringLength(100)]
        public string Nombre { get; set; }
    }
}
