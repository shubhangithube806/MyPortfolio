﻿using MyPortfolio.CommonFiles;
using MyPortfolio.Models;
using MyPortfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class CreatePortfolioController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: CreatePortfolio
        public ActionResult Index()
        {
            CreatePortfolioViewModel model = new CreatePortfolioViewModel();

            model.Init(db, Helpers.GetPortfolioUserId(User));
          
            return View(model);
        }
    }
}