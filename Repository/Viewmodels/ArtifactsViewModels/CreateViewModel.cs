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
        public IEnumerable<SelectListItem> Ratings { get; set; } = new List<SelectListItem>();

        public string[] Tag { get; set; }
        public IEnumerable<SelectListItem> Tags { get; set; } = new List<SelectListItem>();

        public string[] Project { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; } = new List<SelectListItem>();

        public string[] Domain { get; set; }
        public IEnumerable<SelectListItem> Domains { get; set; } = new List<SelectListItem>();

    }
}