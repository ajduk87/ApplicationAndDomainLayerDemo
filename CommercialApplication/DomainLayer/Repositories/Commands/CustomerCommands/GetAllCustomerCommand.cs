﻿using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.CustomerCommands
{
    public class GetAllCustomerCommand : CommandBase, ICustomerCommand
    {
        public IEnumerable<Customer> Execute(IDbConnection conn, IDbTransaction transaction = null)
        {
            List<Customer> customers = new List<Customer>();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("select_customer", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Customer customer = new Customer
                {
                    Id = new Id(Convert.ToInt64(dr["Id"].ToString())),
                    Name = new Name(dr["Name"].ToString())
                };

                customers.Add(customer);
            }

            connection.Close();

            return customers;
        }
    }
}
