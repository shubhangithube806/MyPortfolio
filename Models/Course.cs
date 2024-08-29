using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Course
    {
        public Guid CourseId { get; set; }

        public Guid PortfolioUserId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Course Name")]
        public string CourseName { get; set; }

        
        [Required]
        [StringLength(100)]
        [Display(Name = "Course Platform")]
        public string CoursePlatform { get; set; }


        [Required]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }


        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }


        [StringLength(200)]
        public string Skills { get; set; }
    }
}