using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels.ProblemDomainViewModels
{
    public class DetailsDomainViewModel
    {
        [Display(Name = "Name of problem domain")]
        public string Name { get; set; }
        [Display(Name = "Description of problem domain")]
        public string Description { get; set; }

        public int[] SubTaskIds { get; set; }
        public List<SubTask> SubTasks { get; set; }
    }
}