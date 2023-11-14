﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;



namespace ViewModel
{
    public class UserDB : BaseDB
    {
        // מכין משתמש על פי בקשה ומחזיר אותה
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.Id = int.Parse(reader["id"].ToString());
            user.FirstName = reader["firstName"].ToString();
            user.LastName = reader["lastName"].ToString();
            user.Email = reader["email"].ToString();
            user.Password = reader["password"].ToString();
            user.Gender = bool.Parse(reader["gender"].ToString());
            user.Phonenum = reader["phoneNum"].ToString();
            user.IsWorker = bool.Parse(reader["IsWorker"].ToString());
            user.WorkerRank = int.Parse(reader["WorkerRank"].ToString());
            user.Birthday = DateTime.Parse(reader["birthday"].ToString());
            user.realid = reader["RealId"].ToString();
            return user;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@id", user.Id);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@gender", user.Gender);
            command.Parameters.AddWithValue("@phoneNum", user.Phonenum);
            command.Parameters.AddWithValue("@IsWorker", user.IsWorker);
            command.Parameters.AddWithValue("@WorkerRank", user.WorkerRank);
            command.Parameters.AddWithValue("@birthday", user.Birthday);
            command.Parameters.AddWithValue("@RealId", user.realid);
        }

        protected override BaseEntity NewEntity()
        {
            return new  User() as BaseEntity;
        }
        // מביא את כל המשתמשים הקיימים במערכת
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblUsers";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        // מביא את המשתמש שמבקשים על פי ID 
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblUsers WHERE id=" + id;
            UserList users = new UserList(ExecuteCommand());
            if (users.Count == 0)
                return null;
            return users[0];
        }
        
    }
}
