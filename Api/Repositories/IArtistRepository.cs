using System;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Artist;

namespace Api.Repositories
{
    public interface IArtistRepository
    {
        Task<ArtistModel> GetInfo(string artistUid, string artistName);
    }
}
