using Application.Commands.Comments.Quary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Comments.Quary.GetAllComments
{
    public class GetCommentsListVm:IRequest<CommentsList>
    {

    }
}
