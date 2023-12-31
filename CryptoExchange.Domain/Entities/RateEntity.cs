using CryptoExchange.Core.Abstraction.Data.Entity;

namespace CryptoExchange.Domain.Entities
{
    public class RateEntity : IEntity<string>
    {
        private readonly double _rate;

        public RateEntity(string id, double rate)
        {
            Id = id;
            _rate = rate;
        }

        public string Id { get; }

        public double Rate => _rate;
    }
}