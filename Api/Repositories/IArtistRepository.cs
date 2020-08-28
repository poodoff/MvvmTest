using System;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Artist;

namespace Api.Repositories
{
	///<summary>
	/// Access to artist info
	///</summary>
    public interface IArtistRepository
    {
        Task<ArtistModel> GetInfo(string artistUid, string artistName);
    }
}
