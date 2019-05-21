using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels
{
    public class TagViewModel:PropertyViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Description of tag")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Name of tag")]
        public string Name { get; set; }

        [Display(Name = "Usage number of tag")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int TagUsage { get; set; }

        public TagViewModel()
        {

        }
        public TagViewModel(Tag model)
        {
            Id = model.Id;
            Description = model.Description;
            Name = model.Name;
            TagUsage = model.TagUsage;
        }

        public Tag GetModel()
        {
            return new Tag() { Id = this.Id, Name = this.Name, Description = this.Description, TagUsage = this.TagUsage  };
        }
    }
}