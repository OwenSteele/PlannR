using PlannR.App.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.UI
{
    public class DeleteItemViewModel
    {
        [Required]
        public string RequiredName { get; set; }
        [Required]
        [MustMatch("RequiredName")]
        public string Input { get; set; }
    }
}
