using System;
using System.ComponentModel.DataAnnotations;

namespace models.ViewModels
{
    public class UsuarioViewModel
    {
        public int idUsuario { get; set; }
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        [Required]
        [Display(Name = "CorreoElectronico")]
        public string CorreoElectronico { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name = "FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string PaisOrigen { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string TipoIdentificacion { get; set; }
    }
}
