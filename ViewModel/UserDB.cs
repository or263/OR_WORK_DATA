using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModel
{
    public class UserDB : BaseDB
    {

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.Id = int.Parse(reader["id"].ToString());
            user.FirstName = reader["firstname"].ToString();
            user.LastName = reader["lastname"].ToString();
            user.Email = reader["email"].ToString();
            user.Password = reader["password"].ToString();
            user.UserName = reader["username"].ToString();
            user.PhoneNum = reader["phonenum"].ToString();
            user.IsMannger = bool.Parse(reader["ismanneger"].ToString());
            return user;
        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tbCity";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tbCity WHERE id=" + id;
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }


    }
}
