using System;
namespace Core.Bundle
{
    public class DetailNavArgs
    {
        public string ArtistUid { get; }

        public DetailNavArgs(string artistUid)
        {
            ArtistUid = artistUid;
        }
    }
}
