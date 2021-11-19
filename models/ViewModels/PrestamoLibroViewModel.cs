using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.ViewModels
{
    public class PrestamoLibroViewModel
    {
        public int IdPrestamoLibro { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "FechaPrestamo")]
        public System.DateTime FechaPrestamo { get; set; }
        public bool FueDvuelto { get; set; }
        public string ObservacionEntrega { get; set; }
        public string ObservacionPrestamo { get; set; }

        [Required]
        public int IdLibro { get; set; }

        public string Libro { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        public string Usuario { get; set; }
    }
}
