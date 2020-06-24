using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class Comment 
    {
        [Key]
        public int id { get; set; }
        public string FromId { get; set; }
        public AppUser From { get; set ; }
        public string ArticleToId { get; set; }
        public Article ArticleTo { get ; set ; }
        public string Message { get; set; }
    }
}
