using Application.Commands.Comments.Quary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Comments.Quary.GetCommentsByArticle
{
    public class GetCommentsByArticleVm:IRequest<CommentsList>
    {
        public string Id { get; set; }
    }
}
