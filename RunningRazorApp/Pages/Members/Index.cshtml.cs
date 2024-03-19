using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.Model;
using RunLib.Repository;
using RunningRazorApp.services;
using static RunLib.Model.Member;

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

        public User user { get; set; }

        //Hent alle kunder når siden læses
        public IActionResult OnGet()
        {
            Members = _memberRepo.GetAll();
            try
            {
                user = SessionHelper.Get<User>(HttpContext);
                return Page();
            }
            catch (ArgumentException ne)
            {
                return RedirectToPage("/Login/Index");
            }
        }



        //Gør at man søger når man trykker på knappen
        public IActionResult OnPostSearch()
        {
            Members = _memberRepo.Search(SearchId, SearchName, SearchTeam);
            return Page();
        }

        public IActionResult OnPostMember()
        {
            return RedirectToPage("OpretMember");
        }

        public void OnPostReverseId()
        {
            Members = _memberRepo.GetAll();

            Members.Sort(new MemberSortByIdReverse());
        }

        public void OnPostSortName()
        {
            Members = _memberRepo.GetAll();

            Members.Sort();
        }

        public void OnPostSortNameDB()
        {
            Members = _memberRepo.GetAllDrinksSortedByNameReversed();

        }

        public void OnPostSortTeam()
        {
            Members = _memberRepo.GetAll();

            Members.Sort(new MemberSortByTeam());
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
