using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Profiles
{
    public class AlbumsProdile : Profile
    {
        public AlbumsProdile()
        {
            CreateMap<Entities.Album, Models.AlbumsDto>().ReverseMap();
        }
    }
}
