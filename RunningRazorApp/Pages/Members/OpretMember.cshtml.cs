using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.Model;
using RunLib.Repository;
using System.ComponentModel.DataAnnotations;

namespace RunningRazorApp.Pages.Members
{
    public class OpretMemberModel : PageModel
    {
        private IMemberRepository _repo;

        //Dependency Injection
        public OpretMemberModel(IMemberRepository Memberrepo)
        {
            _repo = Memberrepo;
        }

        //Property til nye v�rdier
        [BindProperty]
        public int NewMemberId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der skal v�re et navn")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal v�re mindst to tegn i et navn")]
        public string NewMemberName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "SORRY SIR! THE PHONENUMBER IS EITHER TOO SHORT OR TOO LONG!")]
        public string NewMemberPhoneNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "hellooooooooooo sir! this team doesnt exist")]
        public string NewMemberTeam { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Most be higher than 0")]
        public double NewMemberPrice { get; set; }

        //Property til fejlbesked
        public string ErrorMessage { get; private set; }

        public void OnGet()
        {
        }


        //N�r man laver �ndringerne tager den alle de nye v�rdier og �ndre dem med de gamle til den specifikke kunde
        public IActionResult OnPost()
        {
            ErrorMessage = "Kunne ikke oprette Member, da membernummer er i brug. V�lg gerne et andet Membernummer";

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Member NewMember = new Member(NewMemberId, NewMemberName, NewMemberPhoneNumber, NewMemberTeam, NewMemberPrice);

            try
            {
                //KundeRepository repo = new KundeRepository(true);
                _repo.Add(NewMember);
                TempData["SuccessMessage"] = $"Customer {NewMemberName} added successfully with ID {NewMemberId}.";
            }
            //fejlbesked, hvis noget g�r galt
            catch (ArgumentException ae)
            {
                ErrorMessage = ae.Message;
                return Page();
            }

            return RedirectToPage("Index");

        }

        //Tjekker om kunde eksistere med det ID, da kunder ikke m� have samme id


        // F�r en tilbage hvis man fortyder
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
