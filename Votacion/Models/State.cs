using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Votacion.Models
{
    public class State
    {
        [Key]
        public int Id_State { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, ErrorMessage = "el campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 3)]


        [Display(Name = "Descripción de estado")]
        public string Description { get; set; }

        public virtual ICollection<Voting> Votings { get; set; }

    }
}