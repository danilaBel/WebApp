using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Comments.DeleteComment
{
    public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentViewModel>
    {
        ICovidDbContext covidDbContext;

        public DeleteCommentRequestHandler(ICovidDbContext covidDbContext)
        {
            this.covidDbContext = covidDbContext;
        }

        public async Task<Unit> Handle(DeleteCommentViewModel request, CancellationToken cancellationToken)
        {
            var Comment = await covidDbContext.Comments.FindAsync(request.Id);
            if (Comment!=null)
            {
                covidDbContext.Comments.Remove(Comment);
                await covidDbContext.SaveChanges(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
