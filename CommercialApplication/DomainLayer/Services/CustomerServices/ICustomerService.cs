﻿using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.CustomerServices
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Select(IDbConnection connection, IDbTransaction transaction = null);
        Customer SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);

        void Insert(IDbConnection connection, Customer customer, IDbTransaction transaction = null);

        void Update(IDbConnection connection, Customer customer, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, Customer customer, IDbTransaction transaction = null);
    }
}