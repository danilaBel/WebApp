using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Articles.Queryes.GetAllArticles
{
    public class ArticleDto
    {
        public string Id { get; set; }
        public AppUser AppUser { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Content { get; set; }
    }
}
