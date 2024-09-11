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
    public class MyProfileImageController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profile Image
        [HttpGet]
        public ActionResult SaveProfileImage(Guid? profileImageId)
        {
            ProfileImage profileImage = new ProfileImage();

            if (profileImageId != null)
            {
                profileImage = db.ProfileImage.Where(m => m.ProfileImageId == profileImageId).FirstOrDefault();
            }

            return View(profileImage);
        }

        [HttpPost]
        public ActionResult SaveProfileImage(ProfileImage profileImage, HttpPostedFileBase imageFile)
        {
            // Check if the file is not selected 

            if (imageFile == null || imageFile.ContentLength == 0)
            {
                // Add a custom error message to the ModelState 

                ModelState.AddModelError("profileImageFile", "Please select an image to upload.");
            }

            if (ModelState.IsValid)
            {
                Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

                PortfolioUser portfolioUser = db.PortfolioUser.Where(m => m.PortfolioUserId == portfolioUserId).FirstOrDefault();

                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    // Set ContentType and ImageData properties 
                    profileImage.ContentType = imageFile.ContentType;

                    profileImage.ImageName = $"{portfolioUser.FirstName} {portfolioUser.LastName} Profile Image";

                    using (var binaryReader = new System.IO.BinaryReader(imageFile.InputStream))
                    {
                        profileImage.ImageData = binaryReader.ReadBytes(imageFile.ContentLength);
                    }
                }

                if (profileImage.ProfileImageId == Guid.Empty)
                {
                    // Add new image entry 
                    profileImage.ProfileImageId = Guid.NewGuid();

                    profileImage.PortfolioUserId = portfolioUser.PortfolioUserId;

                    db.ProfileImage.Add(profileImage);
                }
                else
                {
                    // Edit existing  profileimage entry 
                    db.Entry(profileImage).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

                return RedirectToAction("SaveProfileImage", "MyProfileImage", new { profileImageId = profileImage.ProfileImageId });

            }
            return View(profileImage);
        }

        public ActionResult DeleteProfileImage(Guid profileImageId)
        {
            ProfileImage profileImage = db.ProfileImage.Where(e => e.ProfileImageId == profileImageId).FirstOrDefault();

            if (profileImage != null)
            {
                db.ProfileImage.Remove(profileImage);
                db.SaveChanges();
            }

            return RedirectToAction("SaveProfileImage", "MyProfileImage");
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