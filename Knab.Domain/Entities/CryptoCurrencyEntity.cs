using Knab.Core.Abstraction.Data.Entity;

namespace Knab.Domain.Entities
{
    public class CryptoCurrencyEntity : IEntityIntId
    {
        private readonly string _name;
        private readonly string _symbol;
        private readonly string _slug;

        public CryptoCurrencyEntity(int id, string name, string symbol, string slug)
        {
            Id = id;
            _name = name;
            _symbol = symbol;
            _slug = slug;
        }

        public int Id { get; }

        public string Name => _name;

        public string Symbol => _symbol;

        public string Slug => _slug;
    }
}