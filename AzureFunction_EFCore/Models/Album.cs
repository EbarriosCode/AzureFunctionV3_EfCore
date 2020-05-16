using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunction_EFCore.Models
{
    [Table("Album")]
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        public int ArtistaID { get; set; }
        public Artista Artista { get; set; }

        public string Titulo { get; set; }
        public double Precio { get; set; }
        public int Anio { get; set; }
    }
}
