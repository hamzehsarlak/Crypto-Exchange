using System.Collections.Generic;
using CryptoExchange.Core.IMediatR;
using CryptoExchange.Core.IMediatR.Abstraction;

namespace CryptoExchange.Integration.Commands
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