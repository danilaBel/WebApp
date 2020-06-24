using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }
        public string RepublicId { get; set; }
        public Republic Republic{get;set;}
        public string VirusId { get; set; }
        public Virus Virus { get; set; }
        public double CountInfected { get; set; }
        public double Recovered { get; set; }
        public double Dead { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
