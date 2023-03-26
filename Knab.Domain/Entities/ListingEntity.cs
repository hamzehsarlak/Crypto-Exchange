using Knab.Core.Abstraction.Data.Entity;

namespace Knab.Domain.Entities
{
    public class ListingEntity : IEntityIntId
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