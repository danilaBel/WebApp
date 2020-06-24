using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class Article
    {
      [Key]
      public string Id { get; set; }
      public string AppUserId { get; set; }
      public AppUser AppUser { get; set; }
      public  string Title { get; set; }
      public  string Tags { get; set; }
      public string Content { get; set; }
    }
}
