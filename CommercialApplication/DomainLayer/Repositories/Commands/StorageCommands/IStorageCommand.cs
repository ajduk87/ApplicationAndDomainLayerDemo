﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.StorageCommands
{
    public interface IStorageCommand
    {
        string StoredFunctionName { get; }
    }
}
