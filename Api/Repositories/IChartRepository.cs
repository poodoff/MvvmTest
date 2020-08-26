using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Repositories
{
    public interface IChartRepository
    {
        Task<IReadOnlyList<SimpleArtistModel>> GetTopAtists(int limit = 100);
    }
}
