using Application.Commands.Articles.Queryes.GetAllArticles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Articles.ArticleDetail
{
    public class ArticleDetailVm:IRequest<ArticleDto>
    {
        public string Id { get; set; }
    }
}
