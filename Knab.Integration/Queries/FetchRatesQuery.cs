﻿using System.Collections.Generic;
using Knab.Core.IMediatR;

namespace Knab.Integration.Queries
{
    public class FetchRatesQuery : MediatRQueryBase<Dictionary<string, double>>
    {
        public FetchRatesQuery(string baseSymbol = "USD", List<string> symbols = null)
        {
            BaseSymbol = baseSymbol;
            Symbols = symbols ?? new List<string> { "EUR", "BRL", "GBP", "AUD" };
        }

        public string BaseSymbol { get; set; }

        // output currencies
        public List<string> Symbols { get; set; }
    }
}