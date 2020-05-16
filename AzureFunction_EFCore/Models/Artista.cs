using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunction_EFCore.Models
{
    [Table("Artista")]
    public class Artista
    {
        [Key]
        public int ArtistaID { get; set; }
        public string Nombre { get; set; }
    }
}
