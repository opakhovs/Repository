using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels.SubTasksViewModels
{
    public class CreateViewModel
    {
        [Required, Display(Name = "Name")]
        public string Name { get; set; }
        [Required, Display(Name = "Description")]
        public string Description { get; set; }

        public int[] SubTaskIds { get; set; }
        public List<SubTask> SubTasks { get; set; }
    }
}