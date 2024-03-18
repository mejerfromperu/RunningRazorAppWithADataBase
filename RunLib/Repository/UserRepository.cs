using RunLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.Repository
{
    public class UserRepository
    {

        private List<User> _repo;

        public UserRepository(bool mocdata = false)
        {
            _repo = new List<User>();

            if(mocdata == true)
            {
                _repo.Add(new User("jimmy", "Jonny", "43987677", false));
                _repo.Add(new User("Mike", "Jens", "99887766", false));
                _repo.Add(new User("CookieMan", "Miller", "88776633", false)) ;
                _repo.Add(new User("Midgethunter", "Niller", "99889992", false));
                _repo.Add(new User("Kilomaker", "Rotte", "Roteater", false));
            }
        }

        public void add(User user)
        {
            User newuser = new User(user.Username, user.Password, user.Name, user.Admin);
            _repo.Add(newuser);
        }

        public User Delete(string username)
        {
            User? user = _repo.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                _repo.Remove(user);
            }
            return user;
        }

        public bool CheckUser(string username, string password)
        {
            User? user = _repo.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user == null)
            {
                throw new ArgumentException();
            }

            return true;

        }
    }
}
