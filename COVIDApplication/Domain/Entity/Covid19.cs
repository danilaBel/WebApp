using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class Virus : IVirus
    {
        [Key]
        public string Id { get; set; }
        public string Title { get ; set ; }
        public string Description { get; set; }
        public string TransPath { get; set; }
        public string Symptoms { get; set; }
    }
}
