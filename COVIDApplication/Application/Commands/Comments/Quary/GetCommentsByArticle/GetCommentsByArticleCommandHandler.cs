using Application.Commands.Comments.Quary.Models;
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

namespace Application.Commands.Comments.Quary.GetCommentsByArticle
{
    public class GetCommentsByArticleCommandHandler : IRequestHandler<GetCommentsByArticleVm,CommentsList>
    {
        ICovidDbContext context_;
        UserManager<AppUser> UserManager;

        public GetCommentsByArticleCommandHandler(ICovidDbContext context_, UserManager<AppUser> userManager)
        {
            this.context_ = context_;
            UserManager = userManager;
        }

        public async Task<CommentsList> Handle(GetCommentsByArticleVm request, CancellationToken cancellationToken)
        {
            var comments = await context_.Comments.ToListAsync(cancellationToken);

            return new CommentsList()
            {
                Comments = comments.Where(x => x.ArticleTo.Id == request.Id).Select(x => new CommentDto()
                {
                    Id = x.id.ToString(),
                    ArticleTo = x.ArticleTo,
                    ArticleToId = x.ArticleToId,
                    From = UserManager.FindByIdAsync(x.FromId).Result,
                    FromId = x.FromId
,
                    Message = x.Message
                }).ToList()
            };
        }
    }
}
