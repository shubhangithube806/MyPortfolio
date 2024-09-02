﻿using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.ViewModels
{
    public class CreatePortfolioViewModel
    {
        public Guid BasicInfoId { get; set; }

        public int EducationCount { get; set; }
        public int ExperienceCount { get; set; }
        public int CourseCount { get; set; }
        public int SkillCount { get; set; }
        public int LanguageCount { get; set; }


        public void Init(ApplicationDbContext db, Guid portfolioUserId)
        {

            this.BasicInfoId = db.BasicInfo.Where(m => m.PortfolioUserId == portfolioUserId).Select(m => m.BasicInfoId).FirstOrDefault();

            this.EducationCount = db.Education.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.ExperienceCount = db.Experience.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.CourseCount = db.Course.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.SkillCount = db.Skill.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.LanguageCount = db.Skill.Where(m => m.PortfolioUserId == portfolioUserId).Count();

        }
    }
}