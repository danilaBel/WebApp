using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class Republic
    {
        [Key]
        public string Title { get; set; }
        public double Population { get; set; }
        public double Square { get; set; }
    }
}
