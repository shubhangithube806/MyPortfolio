using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Hobby
    {
        public Guid HobbyId { get; set; }

        public Guid PortfolioUserId { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }
    }
}