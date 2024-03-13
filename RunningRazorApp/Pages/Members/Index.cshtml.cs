using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.Model;
using RunLib.Repository;

namespace RunningRazorApp.Pages.Members
{
    public class IndexModel : PageModel
    {
        // instans af kunde repository
        private IMemberRepository _memberRepo;

        //Dependency Injection
        public IndexModel(IMemberRepository repository)
        {
            _memberRepo = repository;
        }

        // property til View'et
        public List<Member> Members { get; set; }

        // BindProperty til search funktion

        [BindProperty]
        public int? SearchId { get; set; }
        [BindProperty]
        public string? SearchName { get; set; }
        [BindProperty]
        public string? SearchTeam { get; set; }


        //Hent alle kunder n�r siden l�ses
        public void OnGet()
        {
            Members = _memberRepo.GetAll();
        }



        //G�r at man s�ger n�r man trykker p� knappen
        public IActionResult OnPostSearch()
        {
            Members = _memberRepo.Search(SearchId, SearchName, SearchTeam);
            return Page();
        }

        public IActionResult OnPostMember()
        {
            return RedirectToPage("OpretMember");
        }

        //Kalder Sort efter ID
        //public IActionResult OnPostSortId()
        //{
        //    Customers = _customerRepo.SortId();
        //    return Page();
        //}

        //Kalder sort efter navn
        //public IActionResult OnPostSortName()
        //{
        //    Customers = _customerRepo.SortName();
        //    return Page();
        //}
    }
}
