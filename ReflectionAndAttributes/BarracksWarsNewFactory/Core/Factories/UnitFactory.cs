using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string unitNamespace = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            Type classType = Type.GetType($"{unitNamespace}{unitType}");
            var classInstance = Activator.CreateInstance(classType);
            return (IUnit)classInstance;
        }
    }
}
