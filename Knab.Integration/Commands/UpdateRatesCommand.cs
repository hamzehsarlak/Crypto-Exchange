using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Core.IMediatR.Abstraction;

namespace Knab.Integration.Commands
{
    public class UpdateRatesCommand : MediatRCommandBase<bool>, IMediatRCommand
    {
        public Dictionary<string, double> Rates { get; }

        public UpdateRatesCommand(Dictionary<string, double> rates)
        {
            Rates = rates;
        }
    }
}