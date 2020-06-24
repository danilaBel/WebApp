using Application.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Articles.Queryes.GetAllArticles
{
    public class GetArticleListCommandHandler : IRequestHandler<GetArticleListVm, ArticleList>
    {
        ICovidDbContext context_;
        UserManager<AppUser> UserManager;

        public GetArticleListCommandHandler(ICovidDbContext context_, UserManager<AppUser> userManager)
        {
            this.context_ = context_;
            UserManager = userManager;
        }

        public async Task<ArticleList> Handle(GetArticleListVm request, CancellationToken cancellationToken)
        {
            var Articles = await context_.Articles.ToListAsync(cancellationToken);
            return new ArticleList()
            {
                Articles = Articles.Select(x => new ArticleDto()
                {Id=x.Id, AppUser = UserManager.FindByIdAsync(x.AppUserId).Result, Content = x.Content, Tags = x.Tags, Title = x.Title }).ToList()
            };
        }
    }
}
