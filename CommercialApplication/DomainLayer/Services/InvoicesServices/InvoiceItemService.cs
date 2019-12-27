﻿using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Repositories.ActionRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IInvoiceItemRepository invoiceItemRepository;
        private readonly IActionRepository actionRepository;
        private readonly IProductRepository productRepository;

        public InvoiceItemService()
        {
            this.invoiceItemRepository = RepositoryFactory.CreateInvoiceItemRepository();
            this.actionRepository = RepositoryFactory.CreateActionRepository();
            this.productRepository = RepositoryFactory.CreateProductRepository();
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            this.invoiceItemRepository.Delete(connection, id);
        }

        public long Insert(IDbConnection connection, InvoiceItem invoiceItem, IDbTransaction transaction = null)
        {
            return this.invoiceItemRepository.Insert(connection, invoiceItem);
        }

        public Money IncludeBasicDiscountForPaying(IDbConnection connection, InvoiceItem invoiceItem, IDbTransaction transaction = null)
        {
            dynamic action = this.actionRepository.SelectById(connection, invoiceItem.ActionId.Content);
            Id id = new Id(invoiceItem.ProductId);
            double.TryParse(this.productRepository.SelectById(connection, id).UnitCost
                                                                             .Split(' ')
                                                                             .ToList()
                                                                             .First(), out double unitCost);
            return invoiceItem.Amount.Content > action.ThresholdAmount ? new Money { Value = invoiceItem.Amount * unitCost * invoiceItem.DiscountBasic } : new Money { Value = invoiceItem.Amount * unitCost };
        }
    }
}