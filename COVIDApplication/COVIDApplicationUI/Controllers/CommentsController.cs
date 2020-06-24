using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Comments.AddComment;
using Application.Commands.Comments.DeleteComment;
using Application.Commands.Comments.Quary.GetAllComments;
using Application.Commands.Comments.Quary.GetCommentByUser;
using Application.Commands.Comments.Quary.GetCommentsByArticle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COVIDApplicationUI.Controllers
{
    public class CommentsController : BaseController
    {
        // GET: CommentsController
        public async Task<ActionResult> Index()
        {
            return View(await Mediator.Send(new GetCommentsListVm()));
        }

        public async Task<ActionResult> UserComments(string UserEmail)
        {
            return View(await Mediator.Send(new GetCommentsByUserVm() { UserEmail = UserEmail }));
        }

        // GET: CommentsController/Details/5
        public async Task<ActionResult> ArticleComments([Bind("id")]string id)
        {
            ViewBag.Id = id;
            return View(await Mediator.Send(new GetCommentsByArticleVm() { Id = id }));
        }


        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: CommentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("FromId,ToId,Message")]string FromId,string ToId,string Message, string returnUrl = null)
        {
                await Mediator.Send(new AddCommentViewModel() { FromUserEmail = FromId, ToId = ToId, Message = Message });
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            else return View(); 
           
        }

        // POST: CommentsController/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind("id")]int id)
        {
            Mediator.Send(new DeleteCommentViewModel() { Id = id });
            return RedirectToAction(nameof(Index));

        }
    }
}
