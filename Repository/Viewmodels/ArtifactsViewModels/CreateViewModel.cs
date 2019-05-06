using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Viewmodels.ArtifactsViewModels
{
    public class CreateViewModel
    {
        [Required, Display(Name ="Date of adding"), DataType(DataType.Date)]
        public DateTime DateOfAdding { get; set; }
        [Required, Display(Name ="Version")]
        public string Version { get; set; }
        [Required, Display(Name ="Type")]
        public int ArtifactTypeId { get; set; }
        public List<ArtType> Types { get; set; }

        public int[] RatingIds { get; set; }
        public List<Rating> Ratings { get; set; }

        public int[] TagIds { get; set; }
        public List<Tag> Tags { get; set; } 

        public int[] ProjectIds { get; set; }
        public List<Project> Projects { get; set; } 

        public int[] DomainIds { get; set; }
        public List<ProblemDomain> Domains { get; set; }

        //public int[] SubTaskIds { get; set; }
        //public List<SubTask> SubTasks { get; set; }

    }
}