using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Artist;

namespace Api.Repositories
{
    public interface IChartRepository
    {
        Task<IReadOnlyList<SimpleArtistModel>> GetTopAtists(int limit = 200);
    }
}
