using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Contract;
using System.ComponentModel.DataAnnotations;

namespace TSEP.App.Pages.Projekt
{
    public class CreateModel : PageModel
    {
        private readonly IIgangsættelseService _igangsættelseService;
        public CreateModel(IIgangsættelseService igangsættelseService)
        {
            _igangsættelseService = igangsættelseService;
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
