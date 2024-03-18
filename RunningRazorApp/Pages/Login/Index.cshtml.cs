using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.Model;
using RunningRazorApp.services;

namespace RunningRazorApp.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public String Name { get; set; }

        [BindProperty]
        public String Pass { get; set; }

        [BindProperty]
        public String Username { get; set; }


        [BindProperty]
        public String ErrorMsg { get; set; }


        public void OnGet()
        {
            ErrorMsg = string.Empty;

        }

        public IActionResult OnPost()
        {
            if (Username is null || Pass is null)
            {
                ErrorMsg = "Du skal skrive navn og Kodeord";
                return Page();
            }

            if (Username != "Jonny" || Pass != "43987677")
            {
                ErrorMsg = "Navn eller Kodeord er ikke korrekt";
                return Page();
            }

            User user = new User(Name, Username, Pass, false);
            SessionHelper.Set(user, HttpContext);

            return RedirectToPage("/Members/Index");
        }

    }
}
