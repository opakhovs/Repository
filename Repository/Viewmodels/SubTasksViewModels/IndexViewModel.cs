using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Viewmodels.SubTasksViewModels
{
    public class IndexViewModel
    {
        public MultiSelectList SubTasks { get; set; }

        public int[] SelectedProperties { get; set; }
    }
}