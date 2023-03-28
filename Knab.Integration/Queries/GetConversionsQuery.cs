using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Integration.Dtos;

namespace Knab.Integration.Queries
{
    public class GetConversionsQuery : MediatRQueryBase<IEnumerable<ConversionDto>>
    {
        
    }
}