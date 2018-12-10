using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Votacion.Models
{
    public class Voting
    {

        [Key]
        public int Id_Voting { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [StringLength(50, ErrorMessage = "el campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 3)]
        [Display(Name = "Descripcion de votos")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [Display(Name = "Estado")]
        public int Id_State { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeStart { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString  = "{0:yyyy-MM-dd hh-mm tt}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeEnd { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [Display(Name = "Para Todos Los Usuarios")]
        public bool IsForAllUsers { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [Display(Name = "Se Habilita el Voto en Blanco")]
        public bool IsEnableBlankVote { get; set; }

        [Display(Name = "Cantidad de Votos")]
        public int QuantityVote { get; set; }

        [Display(Name = "Cantidad de Votos en Blanco")]
        public int QuantityBlankVotes { get; set; }

        [Display(Name = "Candidato Ganador")]
        public int CandidateWinId { get; set; }


        //Relacionando las tablas

        public virtual State state { get; set; }


    }
}