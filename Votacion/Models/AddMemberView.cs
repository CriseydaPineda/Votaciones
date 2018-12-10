using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Votacion.Models
{
    public class AddMemberView
    {
        public int Id_Group { get; set; }
        [Required(ErrorMessage = "Campo {0}, Es Requerido")]        
        public int UserId { get; set; }

    }
}