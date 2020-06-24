using Application.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Comments.AddComment
{
    public class AddCommentRequestHandler : IRequestHandler<AddCommentViewModel>
    {
        ICovidDbContext covidDbContext;
        UserManager<AppUser> userManager;

        public AddCommentRequestHandler(ICovidDbContext covidDbContext, UserManager<AppUser> userManager)
        {
            this.covidDbContext = covidDbContext;
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(AddCommentViewModel request, CancellationToken cancellationToken)
        {
            var UserFrom = await userManager.FindByEmailAsync(request.FromUserEmail);
            var UserTo = await covidDbContext.Articles.FindAsync(request.ToId);
            if ((UserFrom!=null)&&(UserTo!=null))
            {
                var Comment = new Comment() { FromId = UserFrom.Id, 
                                              From = UserFrom,
                                              ArticleToId = UserTo.Id, 
                                              ArticleTo = UserTo,
                                              Message = request.Message };
                covidDbContext.Comments.Add(Comment);
                await covidDbContext.SaveChanges(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
