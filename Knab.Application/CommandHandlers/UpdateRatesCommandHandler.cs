using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Knab.Core.Abstraction.Data;
using Knab.Core.IMediatR.Abstraction;
using Knab.Domain.Entities;
using Knab.Integration.Commands;

namespace Knab.Application.CommandHandlers
{
    public class UpdateRatesCommandHandler : IMediatRCommandHandler<UpdateRatesCommand, bool>
    {
        private readonly IRepository<RateEntity> _rateRepository;

        public UpdateRatesCommandHandler(IRepository<RateEntity> rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public async Task<bool> Handle(UpdateRatesCommand command, CancellationToken cancellationToken)
        {
            // map to entity
            var entities = command.Rates.Select(r => new RateEntity(r.Key, r.Value));

            // save to db
            await _rateRepository.Upsert(entities, cancellationToken);
            return true;
        }
    }
}