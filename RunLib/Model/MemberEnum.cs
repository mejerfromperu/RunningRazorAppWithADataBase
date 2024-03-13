using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.Model
{
    public enum TeamColorType { sort, blå, grøn, gul, orange, rød }


    public class MemberEnum
    {
        // instans felter
        private double _price;
        private TeamColorType _team;
        private string _mobile;
        private string _name;
        private int _id;


        // properties
        public int Id
        {
            get { return _id; }
            // evt. private set { _id = value; } så kan den kun tilgås inde i klassen selv
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
                if (value.Length < 3)
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


        public TeamColorType Team
        {
            get { return _team; }
            set { _team = value; }  // OBS ingen tjek pga enum
        }


        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 50)
                {
                    throw new ArgumentException("Pris skal være over 50 Men var " + value);
                }
                _price = value;
            }
        }


        // konstruktører
        public MemberEnum() :
            this(-1, "", "", TeamColorType.rød, 0.0)
        {
        }

        public MemberEnum(string name, string mobile, TeamColorType team, double price) :
            this(-1, name, mobile, team, price)
        {
        }

        public MemberEnum(int id, string name, string mobile, TeamColorType team, double price)
        {
            _id = id;
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
    }
}
