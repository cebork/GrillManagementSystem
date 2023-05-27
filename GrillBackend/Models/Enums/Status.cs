using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrillBackend.Models.Enums
{
    public enum Status
    {
        preparing,
        [Display(Name = "in proggres")]
        in_progress,
        Ended

    }
}
