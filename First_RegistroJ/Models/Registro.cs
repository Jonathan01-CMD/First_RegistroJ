using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First_RegistroJ.Models
{
    public class Registro
    {
        [Key]
        [Required(ErrorMessage = "RegistroID vacio")]
        [Range(0,100, ErrorMessage = "Numero no valido")]
        
        public int RegistroId { set; get; }
        
        [Required(ErrorMessage ="Introdusca su Nombre")]
        [MaxLength(15)]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]

        public string Cedula { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Fecha")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]


        public string Nombres { get; set; }

        [Required(ErrorMessage = "Introdusca su Telefono")]
        [MaxLength(15)]
        [RegularExpression(@"^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Debe ser un numero de telefono")]

        public string Telefono { get; set; }

        [Required(ErrorMessage = "Introdusca su Telefono")]
        [MaxLength(15)]
        [RegularExpression(@"^\\d{3}\\D?\\d{7}\\D?\\d$", ErrorMessage = "Debe ser una Cedula")]

        public DateTime FechaNacimiento { get; set; } = DateTime.Now;



    }
}
