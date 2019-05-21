using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels
{
    public class ProblemDomainViewModel:PropertyViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Description problem domain")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Name of problem domain")]
        public string Name { get; set; }

        public ProblemDomainViewModel()
        {

        }
        public ProblemDomainViewModel(ProblemDomain model)
        { 
            Id = model.Id;
            Description = model.Description;
            Name = model.Name;
        }

        public ProblemDomain GetModel()
        {
            return new ProblemDomain() { Id = this.Id, Name = this.Name, Description = this.Description };
        }
    }
}