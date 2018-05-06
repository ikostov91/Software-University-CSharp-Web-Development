using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace BarrackWarsTheCommandsStrikeBack.Core.Commands
{
    class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitToRemove = this.Data[1];
            this.Repository.RemoveUnit(unitToRemove);
            return $"{unitToRemove} retired!";
        }
    }
}
