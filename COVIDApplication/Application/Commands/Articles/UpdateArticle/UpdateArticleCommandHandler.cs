using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Articles.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleViewModel>
    {
        ICovidDbContext covidDbContext;

        public UpdateArticleCommandHandler(ICovidDbContext covidDbContext)
        {
            this.covidDbContext = covidDbContext;
        }

        public async Task<Unit> Handle(UpdateArticleViewModel request, CancellationToken cancellationToken)
        {
            var Article = await covidDbContext.Articles.FindAsync(request.Id);
            if (Article!=null)
            {
                covidDbContext.Articles.Update(Article);
                await covidDbContext.SaveChanges(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
