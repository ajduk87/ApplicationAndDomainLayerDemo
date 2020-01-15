﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.CommandRequests
{
    public static class ActionCommandRequests
    {
        public const string GetAll = "GetAll";
        public const string Get = "Get";
        public const string Insert = "Insert";
        public const string Update = "Update";
        public const string UpdateActionByCustomerId = "UpdateActionByCustomerId";
        public const string Delete = "Delete";
        public const string IsActionExist = "IsActionExist";
    }
}
