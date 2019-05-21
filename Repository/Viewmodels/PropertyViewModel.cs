using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Viewmodels
{
    public interface PropertyViewModel
    {
        int Id { get; set; }
        string Description { get; set; }
        string Name { get; set; }
    }
}