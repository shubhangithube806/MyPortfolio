using MyPortfolio.CommonFiles;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class MyLinkController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
           Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

           List<Link> LinkList = db.Link.Where(m => m.PortfolioUserId == portfolioUserId).ToList();

           return View(LinkList);
        }

        // GET: MyLink
        [HttpGet]
        public ActionResult SaveLink (Guid? linkId)
        {
            Link link = new Link();

            if (linkId != null)
            {
                link = db.Link.Where(m => m.LinkId == linkId).FirstOrDefault();
            }
            return View(link);
        }


        [HttpPost]
        public ActionResult SaveLink(Link link)
        {
            if (ModelState.IsValid)
            {
                if (link.LinkId == Guid.Empty)
                {
                    //Add Link
                    link.LinkId = Guid.NewGuid();
                    link.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Link.Add(link);
                    db.SaveChanges();
                }
                else
                {
                    //Edit Link
                    db.Entry(link).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MyLink");
            }

            return View(link);
        }

        public ActionResult DeleteLink(Guid linkId)
        {
            Link link = db.Link.Where(e => e.LinkId == linkId).FirstOrDefault();

            if (link != null)
            {
                db.Link.Remove(link);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MyLink");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
