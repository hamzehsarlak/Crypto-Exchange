using System;
using System.Collections.Generic;
using CryptoExchange.Integration.Dtos.Rate;

namespace CryptoExchange.Integration.Dtos
{
    public class ConversionDto
    {
        private IEnumerable<RateDto> _rates;

        public ConversionDto(int id, string name, string symbol, double usdPrice, double btcPrice,
            IEnumerable<RateDto> rates)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
            UsdPrice = usdPrice;
            BtcPrice = btcPrice;
            Conversions = new Dictionary<string, double>();
            Rates = rates;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public double UsdPrice { get; set; }

        public double BtcPrice { get; set; }

        public IEnumerable<RateDto> Rates
        {
            get => _rates;
            set
            {
                _rates = value;
                Conversions.Clear();
                foreach (var rate in _rates)
                {
                    Conversions.Add(rate.Symbol, Math.Round(rate.Rate * UsdPrice, 2, MidpointRounding.AwayFromZero));
                }
            }
        }

        public Dictionary<string, double> Conversions { get; }
    }
}