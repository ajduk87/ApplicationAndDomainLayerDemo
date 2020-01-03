﻿using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
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
        public IEnumerable<Customer> Execute(IDbConnection connection, IDbTransaction transaction = null)
        {
            return new List<Customer>();
        }
    }
}
