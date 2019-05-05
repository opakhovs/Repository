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
        [Required, Display(Name = "Date of adding"), DataType(DataType.Date)]
        public DateTime DateOfAdding { get; set; }
        [Required, Display(Name = "Version")]
        public string Version { get; set; }
    }
}