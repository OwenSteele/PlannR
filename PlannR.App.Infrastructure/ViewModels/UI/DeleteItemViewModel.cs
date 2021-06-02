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
        [Required(ErrorMessage = "Cannot be empty")]
        [MustMatch("RequiredName",ErrorMessage = "Must match exactly")]
        public string Input { get; set; }
    }
}
