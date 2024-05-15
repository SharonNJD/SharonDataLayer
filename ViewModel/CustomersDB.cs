﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.BankAccount;
using static Model.Customers;

namespace ViewModel
{
    public class CustomersDB : UserDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            base.CreateModel(entity);
            Customers Customer = entity as Customers;
            Customer.dateOfJoining = DateTime.Parse(reader["DateOfJoining"].ToString());         
            Customer.isNative = bool.Parse(reader["IsNative"].ToString());


            return Customer;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Customers Customer = entity as Customers;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@DateOfJoining", Customer.dateOfJoining);
            command.Parameters.AddWithValue("@IsNative", Customer.isNative);
            command.Parameters.AddWithValue("@UserId", Customer.Id);

        }
        public int Insert(Customers Customer)
        {
            command.CommandText = "INSERT INTO tblCustomers (DateOfJoining,IsNative,UserId)" +
                " VALUES (@DateOfJoining,@IsNative,@UserId)";
            LoadParameters(Customer);
            return ExecuteCRUD();
        }

        public int Update(Customers Customer)
        {
            command.CommandText = "UPDATE tblCustomers SET DateOfJoining = @DateOfJoining,IsNative = @IsNative WHERE UserId = @UserId";
            LoadParameters(Customer);
            return ExecuteCRUD();
        }

        public int Delete(Customers Customer)
        {
            command.CommandText = "DELETE FROM tblCustomers WHERE UserId =@UserId";
            LoadParameters(Customer);
            return ExecuteCRUD();
        }

        protected override BaseEntity NewEntity()
        {
            return new Customers() as BaseEntity;
        }
        public CustomersList SelectAll()
        {
            command.CommandText = "SELECT * FROM (tblUsers INNER JOIN tblCustomers ON tblUsers.id = tblCustomers.UserId)";
            CustomersList list = new CustomersList(ExecuteCommand());
            return list;
        }
        public Customers SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM (tblUsers INNER JOIN tblCustomers ON tblUsers.id = tblCustomers.UserId)" +
                $" WHERE (UserId = {id})";
            CustomersList list = new CustomersList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }
        public Customers SelectByGetById(User user)
        {
            command.CommandText = $"SELECT * FROM (tblUsers INNER JOIN tblCustomers ON tblUsers.id = tblCustomers.UserId) " +
                $"WHERE (UserId = {user.Id})";
            CustomersList list = new CustomersList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }
    }
}
