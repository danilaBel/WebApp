using Application.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Articles.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleViewModel>
    {
        ICovidDbContext covidDbContext;
        UserManager<AppUser> userManager;
        public CreateArticleCommandHandler(ICovidDbContext covidDbContext, UserManager<AppUser> userManager)
        {
            this.covidDbContext = covidDbContext;
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(CreateArticleViewModel request, CancellationToken cancellationToken)
        {
            
            var User = await userManager.FindByIdAsync(request.AppUserId);
            if (User!=null)
            {
                var Article = new Article() { AppUserId = User.Id,
                                    Content = request.Content, 
                                    Tags = request.Tags, 
                                    Title = request.Title };
                covidDbContext.Articles.Add(Article);
                await covidDbContext.SaveChanges(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
