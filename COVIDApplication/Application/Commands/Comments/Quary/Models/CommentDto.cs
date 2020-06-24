using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Comments.Quary.Models
{
    public class CommentDto
    {
        public string Id { get; set; }
        public string FromId { get; set; }
        public AppUser From { get; set; }
        public string ArticleToId { get; set; }
        public Article ArticleTo { get; set; }
        public string Message { get; set; }
    }
}
