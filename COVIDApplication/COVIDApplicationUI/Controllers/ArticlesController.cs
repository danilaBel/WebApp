using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Articles.ArticleDetail;
using Application.Commands.Articles.CreateArticle;
using Application.Commands.Articles.DelteArticle;
using Application.Commands.Articles.Queryes.GetAllArticles;
using Application.Commands.Articles.Queryes.GetArticlesByUser;
using Application.Commands.Articles.UpdateArticle;
using Application.Commands.Comments.Quary.GetCommentsByArticle;
using Application.Commands.Comments.Quary.Models;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace COVIDApplicationUI.Controllers
{
    public class ArticlesController : BaseController
    {
        UserManager<AppUser> UserManager;

        public ArticlesController(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        // GET: Articles
        public async Task<ActionResult> Index()
        {
            return View(await Mediator.Send(new GetArticleListVm()));
        }

        // GET: Articles/Details/5
        public async Task<ActionResult> Details([Bind("EmailUser")]string EmailUser)
        {
            return View(await Mediator.Send(new GetArticleByUserVm() {AppUserEmail= EmailUser }));
        }

        // GET: Articles/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateArticleViewModel createArticle)
        {
                createArticle.AppUserId = (await UserManager.GetUserAsync(User)).Id;
                await Mediator.Send(createArticle);
                return RedirectToAction(nameof(Index));
        }

        // GET: Articles/Edit/5
        public async Task<ActionResult> Edit([Bind("Id")]string Id)
        {
            var dict = new Dictionary<ArticleDto, CommentsList>();
            var Article = await Mediator.Send(new ArticleDetailVm() { Id = Id });
            var comments = await Mediator.Send(new GetCommentsByArticleVm() { Id = Id });
            dict.Add(Article, comments);
            return View(dict);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateArticleViewModel updateArticleView)
        {
            try
            {
                await Mediator.Send(updateArticleView);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Delete/5

        // POST: Articles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await Mediator.Send(new DeleteArticleViewModel() { Id = id });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
