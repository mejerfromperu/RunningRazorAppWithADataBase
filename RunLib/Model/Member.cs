using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.Model
{

    public class Member : IComparable<Member>
    {
        private List<string> teamColors = new List<string>()
            {
                "sort", "blå", "grøn", "gul", "orange", "rød"
            };


        // instans felter
        private double _price;
        private string _team;
        private string _mobile;
        private string _name;
        private int _id;


        // properties
        public int Id
        {
            get { return _id; }
            // evt. private set { _id = value; } så kan den kun tilgås inde i klassen selv
            set { _id = value; }
        }


        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Navn skal være 3 tegn langt");
                }

                if (value.Trim().Length < 3)
                {
                    throw new ArgumentException("Navn skal være 3 tegn langt");
                }
                _name = value;
            }
        }


        public string Mobile
        {
            get { return _mobile; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Mobile nummer skal være mellem 8-12 tegn langt");
                }
                if (value.Length < 8 || 12 < value.Length)
                {
                    throw new ArgumentException("Mobile nummer skal være mellem 8-12 tegn langt");
                }
                _mobile = value;
            }
        }


        public string Team
        {
            get { return _team; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("team skal have en farve  (sort, blå, grøn, gul, orange eller rød)");
                }
                if (!teamColors.Contains(value))
                {
                    throw new ArgumentException("team skal have en farve  (sort, blå, grøn, gul, orange eller rød) Men var " + value);
                }
                _team = value;
            }
        }


        public double Price
        {
            get { return _price; }
            set
            {
                
                _price = value;
            }
        }


        // konstruktører
        public Member() :
            this(-1, "abc", "00000000", "rød", 0.0)
        {
        }

        public Member(string name, string mobile, string team, double price) :
            this(-1, name, mobile, team, price)
        {
        }

        public Member(int id, string name, string mobile, string team, double price)
        {
            Id = id;
            Name = name;
            Mobile = mobile;
            Team = team;
            Price = price;
        }





        // To String
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(Name)}={Name}, {nameof(Mobile)}={Mobile}, {nameof(Team)}={Team}, {nameof(Price)}={Price}}}";
        }

        public int CompareTo(Member? member)
        {
            if(member is null)
            {
                return -1 ;
            }



            //if (member.Name == Name)
            //{
            //    return 0 ;
            //}

            //else if(member.Name < Name)
            //{
            //    return +1;
            //}

            //return -1;

            return Name.CompareTo(member.Name);
        }

        public class MemberSortByIdReverse : IComparer<Member>
        {
            public int Compare(Member? x, Member? y)
            {
                if(x is null)
                {
                    return 1;

                }

                if(y is null)
                {
                    return -1 ;
                }

                return y.Id.CompareTo(x.Id);

            }
        }

        public class MemberSortByTeam : IComparer<Member>
        {
            public int Compare(Member? x, Member? y)
            {
                if( x is null )
                {
                    return -1;
                }

                if ( y is null )
                {
                    return -1 ;
                }

                return x.Team.CompareTo(y.Team);

            }


        }

    }
}
