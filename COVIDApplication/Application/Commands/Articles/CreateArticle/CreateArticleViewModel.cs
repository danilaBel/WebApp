using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Articles.CreateArticle
{
    public class CreateArticleViewModel:IRequest
    {
        public string AppUserId { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Content { get; set; }
    }
}
