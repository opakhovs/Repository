using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels.ArtifactsViewModels
{
    public class CreateViewModel
    {
        [Required, Display(Name ="Date of adding")]
        public DateTime DateOfAdding { get; set; }
        [Required, Display(Name ="Version")]
        public string Version { get; set; }
    }
}