using Application.Commands.Articles.Queryes.GetAllArticles;
using Application.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Articles.Queryes.GetArticlesByUser
{
    public class GetArticleByUserCommandHandler : IRequestHandler<GetArticleByUserVm, ArticlesByUserList>
    {
        ICovidDbContext context_;
        UserManager<AppUser> UserManager;

        public GetArticleByUserCommandHandler(ICovidDbContext context_, UserManager<AppUser> userManager)
        {
            this.context_ = context_;
            UserManager = userManager;
        }

        public async Task<ArticlesByUserList> Handle(GetArticleByUserVm request, CancellationToken cancellationToken)
        {
            var user = await UserManager.FindByEmailAsync(request.AppUserEmail);
            if (user!=null)
            {
                var Articles = await context_.Articles.ToListAsync(cancellationToken);
                return new ArticlesByUserList()
                {
                    Articles = Articles.Where(x=>x.AppUserId==user.Id).Select(x => new ArticleDto()
                    {Id=x.Id, AppUser = UserManager.FindByIdAsync(x.AppUserId).Result, Content = x.Content, Tags = x.Tags, Title = x.Title }).ToList()
                };
            }
            throw new Exception();
        }
    }
}
