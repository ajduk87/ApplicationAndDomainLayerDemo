﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ActionCommands
{
    public interface IActionCommand
    {
        string StoredFunctionName { get; }
    }
}
