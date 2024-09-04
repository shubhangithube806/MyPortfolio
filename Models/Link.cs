using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Link
    {
        public Guid LinkId { get; set; }

        public Guid PortfolioUserId { get; set; }

        [Required]
        [StringLength(1000)]
        public string LinkText { get; set; }

        [Required]
        [StringLength(100)]
        public string LinkType { get; set; }
    }
}