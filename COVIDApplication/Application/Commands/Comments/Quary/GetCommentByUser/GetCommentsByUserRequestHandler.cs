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

namespace Application.Commands.Comments.Quary.GetCommentByUser
{
    public class GetCommentsByUserRequestHandler : IRequestHandler<GetCommentsByUserVm, CommentsList>
    {
        ICovidDbContext context_;
        UserManager<AppUser> UserManager;

        public GetCommentsByUserRequestHandler(ICovidDbContext context_, UserManager<AppUser> userManager)
        {
            this.context_ = context_;
            UserManager = userManager;
        }

        public async Task<CommentsList> Handle(GetCommentsByUserVm request, CancellationToken cancellationToken)
        {
            var Comments = await context_.Comments.ToListAsync(cancellationToken);
            return new CommentsList()
            {
                Comments = Comments.Where(x => x.From.Email == request.UserEmail)
                .Select(x => new CommentDto()
                {
                    Id=x.id.ToString(),
                    ArticleTo = x.ArticleTo,
                    ArticleToId = x.ArticleToId,
                    From = UserManager.FindByIdAsync(x.FromId).Result,
                    FromId = x.FromId,
                    Message = x.Message
                }).ToList()
            };
        }
    }
}
