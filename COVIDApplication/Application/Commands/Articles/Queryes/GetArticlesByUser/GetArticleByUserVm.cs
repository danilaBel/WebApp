using Application.Commands.Articles.Queryes.GetAllArticles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Articles.Queryes.GetArticlesByUser
{
    public class GetArticleByUserVm:IRequest<ArticlesByUserList>
    {
        public string AppUserEmail { get; set; }
    }
}
