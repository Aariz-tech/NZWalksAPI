using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks6._0Framework.API.Models.DTOs;
using NZWalks6._0Framework.API.Repository;

namespace NZWalks6._0Framework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _sQLRegionRepository;
        private readonly IMapper _mapper;

        public RegionsController( IRegionRepository sQLRegionRepository, IMapper mapper)
        {
            this._sQLRegionRepository = sQLRegionRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _sQLRegionRepository.GetAllRegionsAsync();
            if(regions == null)
            {
                return NotFound();
            }
            //Map Region domain model to Region DTO  model
            //var regionsDto = new List<RegionDto>();
            //regions.ToList().ForEach(regions=>
            //{
            //    var regionDto = new RegionDto()
            //    {
            //        Id = regions.Id,
            //        Name = regions.Name,
            //        Code = regions.Code,
            //        Area = regions.Area,
            //        Lat = regions.Lat,
            //        Long = regions.Long,
            //        Population = regions.Population,
            //};
                

            //    regionsDto.Add(regionDto);
            //});
            return Ok(_mapper.Map<List<RegionDto>>(regions));
        }
    }
}
