using Application.Commands.Comments.Quary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Comments.Quary.GetCommentByUser
{
    public class GetCommentsByUserVm:IRequest<CommentsList>
    {
        public string UserEmail { get; set; }
    }
}
