using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels.SubTasksViewModels
{
    public class SubTaskViewModel
    {
        public int SubTaskId { get; set; }
        [Required, Display(Name = "Name")]
        public string Description { get; set; }
        [Required, Display(Name = "Description")]

        public string Name { get; set; }
    }
}