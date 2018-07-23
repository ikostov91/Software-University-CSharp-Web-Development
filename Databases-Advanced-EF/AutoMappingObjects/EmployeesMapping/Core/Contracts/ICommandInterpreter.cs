using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesMapping.App.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] input);
    }
}
