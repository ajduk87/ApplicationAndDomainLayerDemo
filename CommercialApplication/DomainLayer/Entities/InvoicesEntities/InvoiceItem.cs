﻿using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.InvoiceItem;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage;

namespace CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities
{
    public class InvoiceItem : Entity
    {
        public ProductId ProductId { get; set; }
        public Amount Amount { get; set; }
        public Money Value { get; set; }
        public Discount DiscountBasic { get; set; }
        public ActionId ActionId { get; set; }
    }
}