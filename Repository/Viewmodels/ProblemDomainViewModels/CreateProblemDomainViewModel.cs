using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Viewmodels.ProblemDomainViewModels
{
    public class CreateProblemDomainViewModel
    {
        [Required, Display(Name = "Name of problem domain")]
        public string Name { get; set; }
        [Display(Name = "Description of problem domain")]
        public string Description { get; set; }

        public int[] SubTaskIds { get; set; }
        public List<SubTask> SubTasks { get; set; }

    }
}