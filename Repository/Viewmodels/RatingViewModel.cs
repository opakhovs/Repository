using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels
{
    public class RatingViewModel:PropertyViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Description of rating")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Name of rating")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number equivalent for this rating")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int RateValue { get; set; }
        public RatingViewModel()
        {

        }
        public RatingViewModel(Rating model)
        {
            Id = model.Id;
            Description = model.Description;
            Name = model.Name;
            RateValue = model.RateValue;
        }

        public Rating GetModel()
        {
            return new Rating() { Id = this.Id, Name = this.Name, Description = this.Description, RateValue = this.RateValue };
        }
    }
}