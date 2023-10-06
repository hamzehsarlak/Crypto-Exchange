using CryptoExchange.Core.Abstraction.Data.Entity;

namespace CryptoExchange.Domain.Entities
{
    public class ListingEntity : IEntity<int>
    {
        private readonly double _usdPrice;
        private readonly double _btcPrice;

        public ListingEntity(int id, double usdPrice, double btcPrice)
        {
            Id = id;
            _usdPrice = usdPrice;
            _btcPrice = btcPrice;
        }

        public int Id { get; }

        public double UsdPrice => _usdPrice;

        public double BtcPrice => _btcPrice;
    }
}