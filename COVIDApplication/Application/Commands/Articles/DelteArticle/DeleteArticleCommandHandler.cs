using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Articles.DelteArticle
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleViewModel>
    {
        ICovidDbContext covidDbContext;

        public DeleteArticleCommandHandler(ICovidDbContext covidDbContext)
        {
            this.covidDbContext = covidDbContext;
        }

        public async Task<Unit> Handle(DeleteArticleViewModel request, CancellationToken cancellationToken)
        {
            var Article = await covidDbContext.Articles.FindAsync(request.Id);
            if (Article!=null)
            {
                covidDbContext.Articles.Remove(Article);
                await covidDbContext.SaveChanges(cancellationToken);
            }
            return Unit.Value; 
        }
    }
}
