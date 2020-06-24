using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Articles.UpdateArticle
{
    public class UpdateArticleViewModel:IRequest
    {
        public string Id { get; set; }
        public string AppUserId { get; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Content { get; set; }
    }
}
