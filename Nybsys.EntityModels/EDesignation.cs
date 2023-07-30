using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.EntityModels
{
    public class EDesignation
    {
     [Key]
     public int Id { get; set; }
     public string Designation { get; set; }

    }
}
