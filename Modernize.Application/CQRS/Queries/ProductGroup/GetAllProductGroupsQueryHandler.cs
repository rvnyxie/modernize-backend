using Modernize.Domain;

namespace Modernize.Application
{
    public class GetAllProductGroupsQueryHandler : IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroup>>
    {

        public async Task<IEnumerable<ProductGroup>> HandleAsync(GetAllProductGroupsQuery query)
        {
            return Enumerable.Empty<ProductGroup>();
        }
    }
}
