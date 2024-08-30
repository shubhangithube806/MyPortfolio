﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Skill
    {
        public Guid SkillId { get; set; }

        public Guid  PortfolioUserId{ get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }
    }

}