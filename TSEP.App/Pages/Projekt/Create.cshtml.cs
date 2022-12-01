using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Contract;
using System.ComponentModel.DataAnnotations;

namespace TSEP.App.Pages.Projekt
{
    public class CreateModel : PageModel
    {
        private readonly IIgangs�ttelseService _igangs�ttelseService;
        public CreateModel(IIgangs�ttelseService igangs�ttelseService)
        {
            _igangs�ttelseService = igangs�ttelseService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [DataType(DataType.DateTime)]
            [Display(Name = "Start DateTime")]
            public string StartDateTime { get; set; }
        }
        public void OnGet()
        {
        }
    }
}
