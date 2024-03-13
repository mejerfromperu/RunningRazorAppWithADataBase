using Microsoft.Data.SqlClient;
using RunLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.Repository
{
    public class MemberRepositoryDB : IMemberRepository
    {
        public Member Add(Member member)
        {
            SqlConnection connection = new SqlConnection(Secrettt.GetConnectionString);
            connection.Open();

            string insertSql = "INSERT INTO Members (Name, Mobile, Team, Price) VALUES (@Name, @Mobile, @Team, @Price)";

            SqlCommand cmd = new SqlCommand(insertSql, connection);
            cmd.Parameters.AddWithValue("@Name", member.Name);
            cmd.Parameters.AddWithValue("@Mobile", member.Mobile);
            cmd.Parameters.AddWithValue("@Team", member.Team);
            cmd.Parameters.AddWithValue("@Price", member.Price);

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);

            connection.Close();
            return member;
        }


        public Member Delete(int id)
        {
            SqlConnection connection = new SqlConnection(Secrettt.GetConnectionString);
            connection.Open();

            string deleteSql = "DELETE FROM Members WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(deleteSql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);

            connection.Close();


            return null;
        }



        public List<Member> GetAll()
        {
            List<Member> list = new List<Member>();

            SqlConnection connection = new SqlConnection(Secrettt.GetConnectionString);
            connection.Open();

            string sql = "SELECT * FROM Members";
            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Member member = ReadMember(reader);
                list.Add(member);
            }


            connection.Close();
            return list;


        }

        private Member ReadMember(SqlDataReader reader)
        {
            Member member = new Member();

            member.Id = reader.GetInt32(0);
            member.Name = reader.GetString(1);
            member.Mobile = reader.GetString(2);
            member.Team = reader.GetString(3);

            member.Price = Convert.ToDouble(reader.GetDecimal(4));

            return member;
        }



        public Member GetById(int id)
        {
            SqlConnection connection = new SqlConnection(Secrettt.GetConnectionString);
            connection.Open();

            string selectSql = "SELECT * FROM Members WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(selectSql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            Member member = null;

            if (reader.Read())
            {
                member = new Member
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Mobile = reader["Mobile"].ToString(),
                    Team = reader["Team"].ToString(),
                    Price = Convert.ToDouble(reader["Price"])
                };
            }

            reader.Close();
            connection.Close();

            return member;
        }


        public Member Update(int id, Member member)
        {
            SqlConnection connection = new SqlConnection(Secrettt.GetConnectionString);
            connection.Open();

            string updateSql = "UPDATE Members SET Name = @Name, Mobile = @Mobile, Team = @Team, Price = @Price WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(updateSql, connection);
            cmd.Parameters.AddWithValue("@Name", member.Name);
            cmd.Parameters.AddWithValue("@Mobile", member.Mobile);
            cmd.Parameters.AddWithValue("@Team", member.Team);
            cmd.Parameters.AddWithValue("@Price", member.Price);
            cmd.Parameters.AddWithValue("@Id", id);

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);

            connection.Close();

            if (rowsAffected > 0)
            {
                return GetById(id);
            }
            return null;
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
            // todo type shit

            List<Member> list = new List<Member>();

            SqlConnection connection = new SqlConnection(Secrettt.GetConnectionString);
            connection.Open();

            string sql = "SELECT * FROM Members ORDER BY Name DESC";
            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Member member = ReadMember(reader);
                list.Add(member);
            }


            connection.Close();
            return list;
        }
    }
}
