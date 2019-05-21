using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels
{
    public class ArtTypeViewModel:PropertyViewModel
    {
        public int Id { get; set; }
        [Display(Name="Description of artifact type")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Name of artifact type")]
        public string Name { get; set; }

        public ArtTypeViewModel()
        {

        }
        public ArtTypeViewModel(ArtType model)
        {
            Id = model.Id;
            Description = model.Description;
            Name = model.Name;
        }

        public ArtType GetModel()
        {
            return new ArtType() { Id = this.Id, Name = this.Name, Description = this.Description };
        }

    }
}