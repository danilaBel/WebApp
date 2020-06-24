using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Comments.AddComment
{
    public class AddCommentViewModel:IRequest
    {
        public string FromUserEmail { get; set; }
        public string ToId { get; set; }
        public string Message { get; set; }
    }
}
