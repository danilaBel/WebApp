using Application.Commands.Comments.Quary.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Comments.Quary.GetAllComments
{
    public class GetAllCommentsListRequestHandler : IRequestHandler<GetCommentsListVm, CommentsList>
    {
        ICovidDbContext context_;

        public GetAllCommentsListRequestHandler(ICovidDbContext context_)
        {
            this.context_ = context_;
        }

        public async Task<CommentsList> Handle(GetCommentsListVm request, CancellationToken cancellationToken)
        {
            var comments = await context_.Comments.ToListAsync(cancellationToken);
            return new CommentsList()
            {
                Comments = comments.Select(x => new Models.CommentDto()
                {
                    Id = x.id.ToString(),
                    ArticleTo = x.ArticleTo,
                    ArticleToId = x.ArticleToId,
                    From = x.From,
                    FromId = x.FromId
,
                    Message = x.Message
                }).ToList()
            };
        }
    }
}
