using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Comments.DeleteComment
{
    public class DeleteCommentViewModel:IRequest
    {
        public int Id { get; set; }
    }
}
