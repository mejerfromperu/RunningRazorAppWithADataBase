using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.Model;
using RunLib.Repository;

namespace RunningRazorApp.Pages.Members
{
    public class DeleteMemberModel : PageModel
    {
            // instans af kunde repository
            private MemberRepository _memberRepo;

            //Dependency Injection
            public DeleteMemberModel(MemberRepository MemberRepository)
            {
                _memberRepo = MemberRepository;
            }

            // property til View'et
            public Member Member { get; private set; }

            // Få den rigtige kunde ud fra kundenummer
            public IActionResult OnGet(int id)
            {
                Member = _memberRepo.GetById(id);
                return Page();
            }

            //Sletter Kunden ud fra kundenummer
            public IActionResult OnPostDelete(int id)
            {
                _memberRepo.Delete(id);
                return RedirectToPage("Index");
            }

            //Får en tilbage til index, hvis man fortryder
            public IActionResult OnPostCancel()
            {
                return RedirectToPage("Index");
            }
        }
    }
