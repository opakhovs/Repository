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
        public string ArtifactType { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; } = new List<SelectListItem>();

        public string[] Rating { get; set; }
        public MultiSelectList Ratings { get; set; }

        public string[] Tag { get; set; }
        public MultiSelectList Tags { get; set; } 

        public string[] Project { get; set; }
        public MultiSelectList Projects { get; set; } 

        public string[] Domain { get; set; }
        public MultiSelectList Domains { get; set; }

        public string[] SubTask { get; set; }
        public MultiSelectList SubTasks { get; set; }

    }
}