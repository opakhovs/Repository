using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels.ArtifactsViewModels
{
    public class ArtifactViewModel
    {
        public int ArtifactId { get; set; }
        [Required, Display(Name = "Date of adding an artifact"), DataType(DataType.Date)]
        public DateTime DateOfAdding { get; set; }
        [Required, Display(Name = "Current version of an artifact")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string Version { get; set; }

        [Display(Name ="Artifact type")]
        public string ArtType { get; set; }

        public List<PropertyViewModel> Properties { get; set; } = new List<PropertyViewModel>();
    }
}