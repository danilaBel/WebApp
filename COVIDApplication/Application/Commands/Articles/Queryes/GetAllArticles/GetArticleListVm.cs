using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Articles.Queryes.GetAllArticles
{
    public class GetArticleListVm:IRequest<ArticleList>
    {
    }
}
