using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Infrastructure_;
using Microsoft.AspNetCore.Authorization;
using Application.Commands.Statistics.GetStatisticDetail;
using Application.Commands.Statistics.AddStatistic;
using Application.Commands.Statistics.UpdateStatistic;
using Application.Commands.Statistics.Queryes.GetStatisticList;

namespace COVIDApplicationUI.Controllers
{

    public class StatisticsController : BaseController
    {
        // GET: Statistics
        public StatisticsController()
        {

        }
        
        public async Task<IActionResult> Index()
        {
            var stats = await Mediator.Send(new GetStatisticListVm());
            return View(stats.statisticList);
        }


        // GET: Statistics/Details/5
        public async Task<IActionResult> Details(StatisticDetailVm id)
        {
            return View(await Mediator.Send(id));
        }

        [Authorize(Roles ="Admin")]
        // GET: Statistics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statistics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddStatisticViewModel statistic)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(statistic);
                return RedirectToAction(nameof(Index));
            }
            return View(statistic);
        }

        // GET: Statistics/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(StatisticDetailVm republic)
        {
            return View(await Mediator.Send(republic));
        }

        // POST: Statistics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateStatisticViewModel statistic)
        {          
            return View(await Mediator.Send(statistic));
        }
    }
}
