using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels
{
    public class ProjectViewModel:PropertyViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Description of project")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Name of project")]
        public string Name { get; set; }

        [Display(Name = "Project owner of project")]
        public string ProjectOwner { get; set; }

        [Display(Name = "Last release of project")]
        [DataType(DataType.Date)]
        public DateTime LastRelease { get; set; }


        public List<Artifact> Artifacts { get; set; } = new List<Artifact>();
        public int[] SelectedIds { get; set; }

        public ProjectViewModel()
        {

        }
        public ProjectViewModel(Project model)
        {
            Id = model.Id;
            Description = model.Description;
            Name = model.Name;
            ProjectOwner = model.ProjectOwner;
            LastRelease = model.LastRelease;
            Artifacts = model.Artifacts;
        }

        public Project GetModel()
        {
            return new Project() { Id = this.Id, Name = this.Name, Description = this.Description, ProjectOwner = this.ProjectOwner, LastRelease = this.LastRelease, Artifacts = this.Artifacts };
        }
    }
}