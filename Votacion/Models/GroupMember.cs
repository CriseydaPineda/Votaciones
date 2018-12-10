using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Votacion.Models
{
    public class GroupMember
    {
        [Key]
        public int GroupMemberId {get;set;}
        public int Id_Group { get; set; }
        public int UserId { get; set; }

        public virtual Group Group { get; set; }

    }
}