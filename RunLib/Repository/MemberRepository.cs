using RunLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RunLib.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly List<Member> _members;

        public MemberRepository()
        {
            _members = new List<Member>();



            _members.Add(new Member(001, "John Doe", "123-456-7890", "rød", 1000));
            _members.Add(new Member(002, "Alice Smith", "987-654-3210", "sort", 1200));
            _members.Add(new Member(003, "Emily Johnson", "555-555-5555", "grøn", 1500));
            _members.Add(new Member(004, "Michael Brown", "111-222-3333", "orange", 1100));
            _members.Add(new Member(005, "Sarah Wilson", "444-444-4444", "orange", 1300));
            _members.Add(new Member(006, "David Lee", "666-666-6666", "rød", 1400));
            _members.Add(new Member(007, "Jessica Martinez", "777-777-7777", "blå", 1200));
            _members.Add(new Member(008, "Ryan Garcia", "888-888-8888", "gul", 1150));
            _members.Add(new Member(009, "Samantha Taylor", "999-999-9999", "grøn", 1600));
            _members.Add(new Member(010, "Andrew Clark", "000-000-0000", "blå", 1550));


        }

        /*
         * CRUD metoder
         */
        public List<Member> GetAll()
        {
            return new List<Member>(_members);
        }

        public Member GetById(int id)
        {
            Member? fundetMember = _members.Find(m => m.Id == id);
            if (fundetMember is null)
            {
                throw new KeyNotFoundException($"Member with id={id} is not found");
            }

            return fundetMember;
        }

        public Member Add(Member m)
        {
            // nu har vi ikke en set til Id 
            // => laver et nyt objekt med et genereret Id

            Member newMember = new Member(GenerateNextId(), m.Name, m.Mobile, m.Team, m.Price);
            _members.Add(newMember);
            return newMember;
        }

        public Member Delete(int id)
        {
            Member sletMember = GetById(id);
            _members.Remove(sletMember);
            return sletMember;
        }

        public Member Update(int id, Member member)
        {
            if (id != member.Id)
            {
                throw new ArgumentException($"Kan ikke updatere et id {id} med et andet {member.Id}");
            }
            Member updateMember = GetById(id);

            // alternativit
            //updateMember.Name = member.Name;
            //updateMember.Mobile = member.Mobile;
            //updateMember.Team = member.Team;
            //updateMember.Price = member.Price;


            int ix = _members.IndexOf(updateMember);
            _members[ix] = member;

            return member;

        }

        public override string? ToString()
        {
            return "Members= [ " + string.Join(", ", _members) + " ]";

        }

        // utility method
        private int GenerateNextId()
        {
            return (_members.Count == 0) ? 1 : _members.Max(m => m.Id) + 1;
        }

        public List<Member> Search(int? id, string? name, string? team)
        {
            List<Member> retMembers = new List<Member>(GetAll());

            if (id != null)
            {
                retMembers = retMembers.FindAll(m => m.Id == id);
            }

            if (name != null)
            {
                retMembers = retMembers.FindAll(m => m.Name.Contains(name));
            }


            if (team != null)
            {
                retMembers = retMembers.FindAll(m => m.Team.Contains(team));
            }

            return retMembers;
        }

        public List<Member> GetAllDrinksSortedByNameReversed()
        {
            throw new NotImplementedException();
        }
    }
}
