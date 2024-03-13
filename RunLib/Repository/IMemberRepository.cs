using RunLib.Model;

namespace RunLib.Repository
{
    public interface IMemberRepository
    {
        Member Add(Member m);
        Member Delete(int id);
        List<Member> GetAll();
        Member GetById(int id);
        string? ToString();
        Member Update(int id, Member member);

        public List<Member> Search(int? id, string? name, string? team);

        List<Member> GetAllDrinksSortedByNameReversed();


    }
}