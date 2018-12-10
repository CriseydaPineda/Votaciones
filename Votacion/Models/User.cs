﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Votacion.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [StringLength(100, ErrorMessage = "el campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        [Index("UserNameIndex", IsUnique = true)]
        [Display(Name = "Correo Electronico")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [StringLength(50, ErrorMessage = "el campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 12)]
        [Display(Name = "Nombre")]
        public string FristName { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [StringLength(50, ErrorMessage = "el campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 12)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        public string FullName { get { return string.Format("{0} {1}", this.FristName, this.LastName); } }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [StringLength(20, ErrorMessage = "el campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 8)]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [StringLength(100, ErrorMessage = "el campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 10)]
        [Display(Name = "Dirección")]
        public string Adress { get; set; }

        [Display(Name = "Grado")]
        public string Grade { get; set; }

        [Display(Name = "Grupo")]
        public string Group { get; set; }

        [StringLength(200, ErrorMessage = "el campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 5)]
        [Display(Name = "Foto")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }



    }
}