using AutoMapper;
using NZWalks6._0Framework.API.Models.Domain;
using NZWalks6._0Framework.API.Models.DTOs;

namespace NZWalks6._0Framework.API.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<Region,AddRegionRequestDto>().ReverseMap();
            CreateMap<UpdateRegionRequestDto,Region>().ReverseMap();
            //for mapping different fields of source and destination
            //CreateMap<Region, RegionDto>()
            //    .ForMember(dest=> dest.Id, options=>options.MapFrom(src=>src.RegionId));
        }

        

    }
}
