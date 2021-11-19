using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.ViewModels
{
    public class LibroViewModel
    {
        public int IdLibro { get; set; }
        [Required]
        public string NombreLibro { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "FechaLanzamiento")]
        public System.DateTime FechaLanzamiento { get; set; }
        public string CantidadPaginas { get; set; }
        public bool Disponible { get; set; }
        [Required]
        public int IdEditorial { get; set; }
        public string Editorial { get; set; }
        public int IdAutor { get; set; }
        [Required]
        public string Autor { get; set; }
    }
}
