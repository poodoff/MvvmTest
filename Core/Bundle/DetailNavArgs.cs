using System;
namespace Core.Bundle
{
    public class DetailNavArgs
    {
        public string ArtistUid { get; }
        public string ArtistName { get; }

        public DetailNavArgs(string artistUid, string atristName)
        {
            ArtistUid = artistUid;
            ArtistName = atristName;
        }
    }
}
