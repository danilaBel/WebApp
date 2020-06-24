using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Articles.DelteArticle
{
    public class DeleteArticleViewModel:IRequest
    {
        public string Id { get; set; }
    }
}
