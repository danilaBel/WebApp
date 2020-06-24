using Application.Commands.Articles.Queryes.GetAllArticles;
using Application.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Articles.ArticleDetail
{
    public class ArticleDetailCommandHandler : IRequestHandler<ArticleDetailVm, ArticleDto>
    {
        ICovidDbContext context_;
        UserManager<AppUser> UserManager;

        public ArticleDetailCommandHandler(ICovidDbContext context_, UserManager<AppUser> userManager)
        {
            this.context_ = context_;
            UserManager = userManager;
        }

        public async Task<ArticleDto> Handle(ArticleDetailVm request, CancellationToken cancellationToken)
        {
            var article = await context_.Articles.FindAsync(request.Id);
            var user = await UserManager.FindByIdAsync(article.AppUserId);
            if (article != null)
            {
                return new ArticleDto()
                {
                    Id = article.Id,
                    AppUser = user,
                    Content = article.Content,
                    Tags = article.Tags,
                    Title = article.Title
                };
            }
            throw new Exception();
        }
    }
}
